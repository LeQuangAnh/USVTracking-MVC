using System;
using System.Linq;
using USVTracking_MVC.Models;

namespace USVTracking_MVC.Utils
{
    public class USVUtils
    {
        private static DBTrackingEntities db = new DBTrackingEntities();

        public static DateTime ConvertToYYYYMMDD(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static string GetName(string id)
        {
            IQueryable<UserMaster> trackingInfoQuery = db.UserMaster.AsQueryable();

            var str = trackingInfoQuery.Where(d => d.UserID == id).FirstOrDefault();

            if (str != null)
            {
                return str.InitialName;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}