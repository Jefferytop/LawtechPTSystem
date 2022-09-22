/*
 PatentInfo_PatentFee 2021-10-07
*/
$(document).ready(function () {
    //初始化Table
    $('#table').bootstrapTable({
        method: 'post',
        url: '/PatentInfo/GetPatentFeeListByPage',
        cache: false,
        //height: 400,
        uniqueId: 'FeeKey',
        striped: true,
        sidePagination: 'server',//server:伺服器端分頁|client：前端分頁
        //search: true, //******开启搜索框****//
        pagination: true,
        pageSize: 10,
        pageList: [5, 10, 30, 50, 100, 200],
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
                PatentNo: $("#txtPatentNo").val()
            };
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



function ReceiptDateFormatter(value, row) {

    var reValue = TransferDate(row.ReceiptDate);

    return reValue;
}

function PayDateFormatter(value, row) {

    var reValue = TransferDate(row.PayDate);

    return reValue;
}

function CreateDateTimeFormatter(value, row) {

    var reValue = TransferDateTime(row.CreateDateTime);

    return row.Creator + "<br>" + reValue;
}

function LastModifyDateTimeFormatter(value, row) {

    var reValue = TransferDateTime(row.LastModifyDateTime);

    return row.LastModifyWorker + "<br>" + reValue;
}
