
//<summary> ajax 綁定 obj 傳輸 </summary>
//<para>
//  url : ajax 連接的 action
//  obj : object
//  successfun : 成功函式
//  errorfun : 失敗函式
//</para>
function bindAjax(url, obj, successfun, errorfun) {
    var jsonSerialized = JSON.stringify(obj);
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        data: jsonSerialized,
        contentType: 'application/json; charset=utf-8',
        success: successfun,
        error: errorfun
    });
}

//<summary> ajax 綁定 data 傳輸 </summary>
//<para>
//  url : ajax 連接的 action
//  data : data  ==>  格式: { loginaccount: $('#spUser').html() };
//  successfun : 成功函式
//  errorfun : 失敗函式
//</para>
function bindAjaxWithData(url, senddata, successfun, errorfun) {
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'text',
        data: senddata,
        //contentType: 'application/json',
        success: successfun,
        error: errorfun
    });
}

//<summary> ajax 綁定 data 傳輸 </summary>
//<para>
//  url : ajax 連接的 action
//  data : data
//  successfun : 成功函式
//  errorfun : 失敗函式
//</para>
function bindAjaxUpload(url, obj, successfun, errorfun) {
    var jsonSerialized = JSON.stringify(obj);
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        data: jsonSerialized,
        cache: false,
        timeout: 1200000,
        async: false,
        //contentType: 'application/json; charset=utf-8',
        success: successfun,
        error: errorfun
    });
}




