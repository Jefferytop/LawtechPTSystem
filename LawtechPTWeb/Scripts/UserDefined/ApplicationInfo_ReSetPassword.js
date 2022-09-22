/* 個人資訊 */
$(document).ready(function () {

    $("#div-msg").hide();

    $('#btnSubmit').click(function () {
        ChangepasswordClick();
    });

});


//新增、修改
function ChangepasswordClick() {
    //debugger
    //取得會員物件    
    var MenuTObject = {
        "OldPassword": $("#OldPassword").val(),
        "NewPassword": $("#NewPassword").val(),
        "ConfirmPassword": $("#ConfirmPassword").val()
    };
    var msgAlter = "";
    var url = "";

    url = '/ApplicationInfo/ChangePassword';
    msgAlter = "恭禧~~，修改密碼成功"

    var successfun = function (context) {
        //alert(context);
        //debugger;
        if (context == "0") { 
            swal.fire("密碼已變更成功", "下次登入時請使用新密碼", "success");
            $("#OldPassword").val('');
            $("#NewPassword").val('');
            $("#ConfirmPassword").val('');
        } else {
            
            swal.fire("修改密碼", context.responseText, "error");
        }
    }
    var errorfun = function (context) {
        //alert(context);
        //debugger;
        swal.fire("修改密碼", context.responseText, "error");
    }
    bindAjax(url, MenuTObject, successfun, errorfun);

}