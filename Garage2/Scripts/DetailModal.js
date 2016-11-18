$('.SlotDetails').on('click', function () {
    $("#DetailModal").dialog({
        autoOpen: true,
        position: { my: "center", at: "top+350", of: window },
        width: 1000,
        resizable: false,
        title: 'Details',
        modal: true,
        open: function () {
            $(this).load('@Url.Action("DetailsPartialView", "Slots")');
        },
        buttons: {
            "Add User": function () {
                addUserInfo();
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        }
    });
    return false;
});
function addUserInfo() {
    $.ajax({
        url: '@Url.Action("AddUserInfo", "Home")',
        type: 'POST',
        data: $("#myForm").serialize(),
        success: function (data) {
            if (data) {
                $(':input', '#myForm')
                  .not(':button, :submit, :reset, :hidden')
                  .val('')
                  .removeAttr('checked')
                  .removeAttr('selected');
            }
        }
    });
}