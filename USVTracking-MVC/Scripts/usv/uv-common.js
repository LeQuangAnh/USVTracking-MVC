$(function () {
    if (typeof window.uv == 'undefined') {
        window.uv = {};
    }
    if (typeof window.uv.util !== 'undefined') { return; };
    window.uv.util = {
        addFormMessage: function ($msg, $form) {
            if (!$form) {
                $form = $('body form').first();
            }
            $msgE = $form.prev('.form-message');
            if ($msgE.length == 0) {
                var $msgE = $('<span class="form-message"></span>');
                $msgE.insertBefore($form);
            }
            if ($.trim($msgE.html()) != '') {
                $msgE.append('<br/>');
            }
            $msgE.append($msg);
            $msgE.show();
            // hack for Chrome redraw.
            $msgE.css('display', 'block');
        },
        addFormError: function ($errMsg, $form) {
            if (!$form) {
                $form = $('body form').first();
            }
            $msgE = $form.prev('.form-error');
            if ($msgE.length == 0) {
                var $msgE = $('<span class="form-error"></span>');
                $msgE.insertBefore($form);
            }
            if ($.trim($msgE.html()) != '') {
                $msgE.append('<br/>');
            }
            $msgE.append($errMsg);
            $msgE.show();
            // hack for Chrome redraw.
            $msgE.css('display', 'block');
        },
        cleanFormMessages: function ($form) {
            if (!$form) {
                $form = $('body form').first();
            }
            $msgE = $form.prev('.form-message');
            if ($msgE.length > 0) {
                $msgE.empty();
            }
            $msgE.hide();
        },
        cleanFormErrors: function ($form) {
            if (!$form) {
                $form = $('body form').first();
            }
            $msgE = $form.prev('.form-error');
            if ($msgE.length > 0) {
                $msgE.empty();
            }
            $msgE.hide();
        }
    };
    /**
    *	common action
    */
    $('.datepicker').datepicker({
        dateFormat: 'yy/mm/dd'
    });

    $(".changeTRPassword").off("click.changeTRPassword").on("click.changeTRPassword", function (e) {
        e.preventDefault();

        var url = $(this).attr('href');
        if (!url) {
            url = $(this).attr('id');
        }
        var id = $(this).attr("id");
        if (!id) {
            id = "change-tr-password-dialog";
        }

        $(".changeTRPassword").closest(".dialog").dialog("close");

        $.ajax({
            url: url,
            dataType: 'html',
            data: { now: $.now() },
            success: function (html) {
                var dialog = $("<div>")
                    .addClass("dialog")
                    .attr("id", id)
                    .appendTo("body")
                    .dialog({
                        title: "User Infomation",
                        close: function () {
                            $(this).remove();
                        },
                        modal: true,
                        width: "auto",
                        height: "auto",
                        resizable: false
                    }).html(html);
            }
        });
    });
});

function initLoading() {
    $('#ajaxloading')
        .hide()
        .ajaxStart(function () {
            if ($.browser.msie && $.browser.version * 1 < 7) {
                $(this).css({
                    position: 'absolute',
                    left: 0,
                    top: 0,
                    width: '100%',
                    height: '100%',
                    border: none,
                    margin: 0,
                    padding: 0
                });
            }
            $(this).show();
        })
        .ajaxStop(function () {
            $(this).hide();
        });

    $(".box-head").toggle(function () {
        $(this).parent().addClass("collapsed");
        $(this).next(".box-body").hide();
    },
    function () {
        $(this).parent().removeClass("collapsed");
        $(this).next(".box-body").show();
    });
}