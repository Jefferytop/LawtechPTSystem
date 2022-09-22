//asp.net日期格式 轉 javascript日期 (yyyy/MM/dd hh:mm:ss)
function TransferDateTime(source) {
    if (typeof (source) == 'undefined' || source == null||source =='') {
        return "";
    }
    var dt = new Date(parseInt(source.substring(6, source.length - 2)));
    if (dt.getFullYear() > 1900) {
        var year = dt.getFullYear() + "";
        var month = (dt.getMonth() + 1) + "";
        var day = dt.getDate() + "";
        var hour = dt.getHours();
        var mouth = dt.getMinutes();
        var second = dt.getSeconds();
        if (month.length == 1) { month = "0" + month; }
        if (day.length == 1) { day = "0" + day; }
        if (hour < 10) { hour = "0" + hour; }
        if (mouth < 10) { mouth = "0" + mouth; }
        if (second < 10) { second = "0" + second; }
        var dtString = year + "/" + month + "/" + day + " " + hour + ":" + mouth + ":" + second;
    }
    else {
        dtString = "";
    }
    return dtString;
}


function TransferDate(source) {
    if (typeof (source) == 'undefined' || source == null || source == '') {
        return "";
    }
    var dt = new Date(parseInt(source.substring(6, source.length - 2)));    
    if (dt.getFullYear() > 1900) {
        var year = dt.getFullYear() + "";
        var month = (dt.getMonth() + 1) + "";
        var day = dt.getDate() + "";
        if (month.length == 1) {
            month = "0" + month;
        }
        if (day.length == 1) {
            day = "0" + day;
        }
        var dtString = year + "/" + month + "/" + day;
    }
    else {
        dtString = "";
    }
    return dtString;
}

