using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USVTracking_MVC.Common;
using USVTracking_MVC.Models;
using USVTracking_MVC.Utils;

namespace USVTracking_MVC.Controllers
{
    public class TimeRecordController : Controller
    {
        /// <summary>
        /// Lấy thông tin người dùng hiện tại
        /// </summary>
        /*private UserMaster CurrentUser
        {
            get { return db.UserMaster.First(u => u.ADName == User.Identity.Name.Substring(7)); }
        }*/

        private DBTrackingEntities db = new DBTrackingEntities();

        private TrackingProgressModel model = null;

        private IList<TrackingInfo> listTracking = null;

        private const int ROW_OF_PAGE = 15;

        //
        // GET: /TimeRecord/
        [HttpGet]
        public ActionResult Index(TrackingProgressModel trackingProgress)
        {
            DateTime fromDate;
            DateTime toDate;

            if (model == null)
            {
                model = new TrackingProgressModel();

                List<ProjectMaster> l = new List<ProjectMaster>();

                var projectList = (from trp in db.TimeRecordProject
                                   join trpu in db.TimeRecordProjectUser on trp.TimeRecordProjectID equals trpu.TimeRecordProjectID
                                   //where trpu.UserID == CurrentUser.UserID && trp.TimeRecordProjectStatus == 1
                                   where trpu.UserID == "400195" && trp.TimeRecordProjectStatus == 1
                                   select trp.TimeRecordProjectName).ToList();

                var projectList1 = (from trp in db.TimeRecordProject
                                    join trpu in db.TimeRecordProjectUser on trp.TimeRecordProjectID equals trpu.TimeRecordProjectID
                                    join pm in db.ProjectMaster on trp.TimeRecordProjectName equals pm.TimeRecordProjectName
                                    //where trpu.UserID == CurrentUser.UserID && trp.TimeRecordProjectStatus == 1 && pm.DelFlag == 0
                                    where trpu.UserID == "400195" && trp.TimeRecordProjectStatus == 1 && pm.DelFlag == 0
                                    select pm.ProjectName).Union(projectList).ToList();

                foreach (var item in projectList1)
                {
                    l.Add(new ProjectMaster { ProjectName = item });
                }

                l.Add(new ProjectMaster { ProjectName = "All" });

                l.Reverse();

                model.ListProject = l;

                model.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy/MM/dd");
                model.EndDate = DateTime.Now.ToString("yyyy/MM/dd");
                model.TaskStatus = new String[] { "All", "Approved", "Unapproved" };
            }

            String approvedFlag = trackingProgress.Status;
            String projectName = trackingProgress.ProjectName;

            try
            {
                fromDate = this.GetDate(trackingProgress.FromDate, 1);
                toDate = this.GetDate(trackingProgress.EndDate, 2);
            }
            catch
            {
                Session["CheckDate"] = "Please input correct date format to 'Date'";
                return View(model);
            }

            if (fromDate > toDate)
            {
                Session[SessionKeyConstant.DateTimeFromTo] = "From date' must before 'To date'";
                return View(model);
            }

            if (trackingProgress != null && approvedFlag != null && projectName != null)
            {

                IQueryable<TrackingInfo> trackingInfoQuery = db.TrackingInfo.AsQueryable();
                if (projectName != "All")
                {
                    trackingInfoQuery = trackingInfoQuery.Where(track => track.ProjectName.Equals(projectName));
                }
                if (approvedFlag.Equals("Approved"))
                {
                    trackingInfoQuery = trackingInfoQuery.Where(
                        track => track.ApprovedFlag == 1
                    );
                }
                else if (approvedFlag.Equals("Unapproved"))
                {
                    trackingInfoQuery = trackingInfoQuery.Where(
                        track => track.ApprovedFlag == 0
                    );
                }
                if (fromDate != DateTime.MinValue)
                {
                    trackingInfoQuery = trackingInfoQuery.Where(track => track.Date >= fromDate);
                }
                if (toDate != DateTime.MaxValue)
                {
                    trackingInfoQuery = trackingInfoQuery.Where(track => track.Date <= toDate);
                }

                //listTracking = trackingInfoQuery.Where(d => d.UserID == CurrentUser.UserID).OrderBy(order => order.ApprovedFlag).ThenByDescending(order => order.Date).ToList();
                listTracking = trackingInfoQuery.Where(d => d.UserID == "400195").OrderBy(order => order.ApprovedFlag).ThenByDescending(order => order.Date).ToList();

                int total;

                model.ListTrackingInfo = this.Get(1, out total, listTracking);

                Session["ListTrackingProcess"] = listTracking;

                ViewData["page"] = 1;
                ViewData["total"] = total;

                if (model.ListTrackingInfo.Count() == 0) Session[SessionKeyConstant.NotFoundTracking] = "Not found tracking.";

            }
            return View(model);
        }

        public ActionResult GetPage(int page)
        {
            int total;
            List<TrackingInfo> list = (List<TrackingInfo>)Session["ListTrackingProcess"];
            model = new TrackingProgressModel() { ListTrackingInfo = this.Get(page, out total, list) };

            ViewData["page"] = page;
            ViewData["total"] = total;

            return PartialView("_TrackingList", model);
        }

        public IList<TrackingInfo> Get(int page, out int total, IList<TrackingInfo> trackingInfoQuery)
        {
            var tracking = (from p in trackingInfoQuery select p).Skip((page - 1) * ROW_OF_PAGE).Take(ROW_OF_PAGE);
            var totalTracking = (from p in trackingInfoQuery select p).Count();
            total = totalTracking / ROW_OF_PAGE + (totalTracking % ROW_OF_PAGE > 0 ? 1 : 0);

            return tracking.ToList();
        }

        /*public JsonResult Delete(decimal[] data)
        {
            if (data != null)
            {
                TrackingInfo t = null;

                foreach (var item in data)
                {
                    t = db.TrackingInfo.First(sd => sd.TrackingNo == item);
                    if (t.ApprovedFlag == 0)
                    {
                        db.TrackingInfo.DeleteObject(t);
                    }
                }
                db.SaveChanges();
            }
            return Json(data);
        }*/

        private DateTime GetDate(string date, int choice)
        {
            DateTime d = new DateTime();

            if (date == null)
            {
                switch (choice)
                {
                    case 1:
                        d = DateTime.MinValue;
                        break;
                    case 2:
                        d = DateTime.MaxValue;
                        break;
                }
            }
            else
            {
                d = USVUtils.ConvertToYYYYMMDD(DateTime.Parse(date));
            }

            return d;
        }
	}
}