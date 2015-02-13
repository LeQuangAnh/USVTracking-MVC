$(function () {

    $('#newBtn').click(function () {
        document.location.href = "SubmitProgessBatch";
    });
    $('#updateBtn').click(function () {
        if($(this).is('.disabled')) { return false; }
        $('form[name=submitForm]').attr('action', 'SubmitProgessBatch/Index?date=' + $.now());
        $('form[name=submitForm]').submit();
    });
    $('#deleteBtn').click(function () {
        if($(this).is('.disabled')) { return false; }
        $('form[name=submitForm]').attr('action', 'TrackingProgress/Delete');
        $('form[name=submitForm]').submit();
    });
    var $chkAll = $('#chkAll');
    var $allCheckBox = $('input[type=checkbox]').not($chkAll).not(":disabled");
    $chkAll.change(function () {
        var checked = $chkAll.is(':checked');
        $allCheckBox.attr('checked', checked);
        $allCheckBox.trigger('change');
    });
    $allCheckBox.change(function () {
        var $allChecked = $allCheckBox.filter(function () {
            return $(this).is(':checked');
        });
        if ($allChecked.length == 0) {
            $('#updateBtn,#deleteBtn').addClass('disabled')
        } else {
            $('#updateBtn,#deleteBtn').removeClass('disabled')
        }
        $chkAll.attr('checked', $allChecked.length == $allCheckBox.length);
    });
    $("#page1").attr("style", "background-color:#DDEEFF; border:1px solid #BBDDFF; font-weight:bold");
});
function onLoadList() {
    var $chkAll = $('#chkAll');
    var $allCheckBox = $('input[type=checkbox]').not($chkAll).not(":disabled");
    $chkAll.change(function () {
        var checked = $chkAll.is(':checked');
        $allCheckBox.attr('checked', checked);
        $allCheckBox.trigger('change');
    });
    $chkAll.attr('disabled', $allCheckBox.length == 0);
    $allCheckBox.change(function () {
        var $allChecked = $allCheckBox.filter(function () {
            return $(this).is(':checked');
        });
        if ($allChecked.length == 0) {
            $('#updateBtn,#deleteBtn').addClass('disabled')
        } else {
            $('#updateBtn,#deleteBtn').removeClass('disabled')
        }
        $chkAll.attr('checked', $allChecked.length == $allCheckBox.length);
    });
    var $allCheckedBox = $(':checked', $allCheckBox);
    if ($allCheckedBox.length == 0) {
        $('#updateBtn,#deleteBtn').addClass('disabled')
    } else {
        $('#updateBtn,#deleteBtn').removeClass('disabled')
    }
}
function OnCriteria(page) {
    $.ajax({
        type: "GET",
        url: "/TrackingProgress/GetPage?page=" + page,
        data: { date: $.now() },
        success: function (result) {
            $("#PersonContainer").html(result);
            onLoadList();
            $("#page" + page).attr("style", "background-color:#DDEEFF; border:1px solid #BBDDFF; font-weight:bold");
        },
        error: function (data) {
            alert(data);
        }
    });
    return false;
}
    