/*
 TrademarkInfo_Index
*/
$(document).ready(function () {
    //初始化Table
    $('#table').bootstrapTable({
        method: 'post',
        url: '/TrademarkInfo/GetTrademarkListByPage',
        cache: false,
        //height: 400,
        uniqueId: 'TrademarkNo',
        striped: true,
        sidePagination: 'server',//server:伺服器端分頁|client：前端分頁
        //search: true, //******开启搜索框****//
        pagination: true,
        pageSize: 10,
        pageList: [10, 30, 50, 100, 200],
        showColumns: true,
        //showPaginationSwitch: true, //分頁/不分頁切換
        showRefresh: true, //重新整理
        showToggle: true, //名片式/table式切換
        minimumCountColumns: 2,
        cardView: false, //卡片视图模式
        clickToSelect: true,
        classes: "table table-bordered table-striped table-sm",//table-striped表示隔行变色
        onLoadSuccess: function (data) {
            //bindTableButton();
        },
        queryParams: function (params) {   //向後臺傳遞的引數
            var p = {
                pageSize: this.pageSize,
                offset: params.offset,
                search: params.search,
                sort: params.sort,
                order: params.order,
                PageNumber: (params.offset / params.limit) + 1,
                TrademarkNo: $("#txtTrademarkNo").val(),
                TrademarkName: $("#txtTrademarkName").val()
            }
            return p;
            },
        onClickRow: function (data) {
            $("#delMsgLabel").text(data.EventContent);
        }
    });

    $("#btnSearch").click(function () {
        $('#table').bootstrapTable('refresh');
    });

});

function RegistrationDateFormatter(value, row) {

    var reValue = TransferDate(row.RegistrationDate);

    return reValue;
}

function LawDateFormatter(value, row) {

    var reValue = TransferDate(row.LawDate);

    return reValue;
}

function ExtendedDateFormatter(value, row) {

    var reValue = TransferDate(row.ExtendedDate);

    return reValue;
}

function ApplicationDateFormatter(value, row) {

    var reValue = TransferDate(row.ApplicationDate);

    return reValue;
}

function PubdateFormatter(value, row) {

    var reValue = TransferDate(row.Pubdate);

    return reValue;
}

//結案日期-結案原因
function CloseDateTimeFormatter(value, row) {

    var reValue = TransferDate(row.CloseDate);

    return reValue + "<br>" + row.CloseCaus;
}

function CreateDateTimeFormatter(value, row) {

    var reValue = TransferDateTime(row.CreateDateTime);

    return row.Creator + "<br>" + reValue;
}

function LastModifyDateTimeFormatter(value, row) {

    var reValue = TransferDateTime(row.LastModifyDateTime);

    return row.LastModifyWorker + "<br>" + reValue;
}
