/*
 PatentInfo_Index
*/
$(document).ready(function () {
    //初始化Table
    $('#table').bootstrapTable({
        method: 'post',
        url: '/PatentInfo/GetPatentListByPage',
        cache: false,
        //height: 400,       
        uniqueId: 'PatentID',
        striped: true,
        //search: true, //******开启搜索框****//
        sidePagination: 'server',//server:伺服器端分頁|client：前端分頁
        pagination: true,
       // onlyInfoPagination:true,
       // pageNumber: 1, //當前第幾頁 
        pageSize: 10,
        pageList: [10, 30, 50, 100, 200],
        //onPageChange: function (number, size) {
            
        //    this.PageNumber = number;
        //    this.pageSize = size;
        //},
        //useCurrentPage: true,
        includeHiddenRows: true,
        showColumns: true,        
        //showPaginationSwitch: true, //分頁/不分頁切換
        showRefresh: true, //重新整理
        showToggle: true, //名片式/table式切換
        showExport: true,//工具栏上显示导出按钮
        //exportDataType: $(this).val(),//显示导出范围
        //exportTypes: ['json', 'xml', 'png', 'csv', 'txt', 'sql', 'doc', 'excel', 'xlsx', 'pdf'],//导出格式
        //exportOptions: {//导出设置
        //    fileName: 'Tablexxx',//下载文件名称
        //},
        //formatShowingRows: function (pageFrom, pageTo, totalRows) {
           // return 'Showing ' + pageFrom + ' to ' + pageTo + ' of ' + totalRows + ' products';
       // },
        queryParams: function (params) {   //向後臺傳遞的引數
            var p = {
                limit: this.pageSize,
                offset: params.offset,
                search: params.search,
                sort: params.sort,
                order: params.order,
                PageNumber: (params.offset / params.limit) + 1,
                ApplicationNo: $("#txtApplicationNo").val(),
                PatentNo: $("#txtPatentNo").val()
            };
            return p;
        },
        minimumCountColumns: 2,
        cardView: false, //卡片视图模式
        clickToSelect: true,
        classes: "table table-bordered table-striped table-sm",//table-striped表示隔行变色
        onLoadSuccess: function (data) {
            //bindTableButton();
        },
        onLoadError: function (e, status, jqXHR) {
            //alert(JSON.stringify(status));
        },
        onClickRow: function (data) {
            $("#delMsgLabel").text(data.EventContent);
        }
    });
   
    $("#btnSearch").click(function () {
        $('#table').bootstrapTable('refresh');
    });

    $("#btnExportCsv").click(function () {
        btnExportCvs();       
    });

});


//匯出csv
function btnExportCvs() {
    var url = '/PatentInfo/ExportCSV';
    var data = {
        "PatentNo": $("#txtPatentNo").val(),
        "ApplicationNo": $("#txtApplicationNo").val()
    };

    bindAjax(url, data, btnExportCvsSuccess, btnExportCvsError);
}

//匯出csv成功
function btnExportCvsSuccess(data) {
    if (data == 0) {
        $('#table').bootstrapTable('refresh');
        $('#MsgModal').modal('show');
        $("#TextMsg").text("匯出.csv成功 ");

    }
}

//匯出csv失敗
function btnExportCvsError(data) {
    $("#TextMsg").text("匯出.csv失敗:" + data.responseText);
    $('#MsgModal').modal('show');
}



//申請日期
function ApplicationDateFormatter(value, row) {

    var reValue = TransferDate(row.ApplicationDate);

    return  reValue;
}

//Pubdate
function PubdateFormatter(value, row) {

    var reValue = TransferDate(row.Pubdate);

    return reValue;
}

//核准日期
function AllowDateFormatter(value, row) {

    var reValue = TransferDate(row.AllowDate);

    return reValue;
}

//公告日期
function AllowPubDateFormatter(value, row) {

    var reValue = TransferDate(row.AllowPubDate);

    return reValue;
}

//收到證書日
function GetDateFormatter(value, row) {

    var reValue = TransferDate(row.GetDate);

    return reValue;
}

//授予專利權日
function RegisterDateFormatter(value, row) {

    var reValue = TransferDate(row.RegisterDate);

    return reValue;
}

//專利權終止日
function DueDateDateFormatter(value, row) {

    var reValue = TransferDate(row.DueDate);

    return reValue;
}

//年費有效期限
function RenewToDateFormatter(value, row) {

    var reValue = TransferDate(row.RenewTo);

    return reValue;
}

function AllowPubDateFormatter(value, row) {

    var reValue = TransferDate(row.AllowPubDate);

    return reValue;
}

//結案日期-結案原因
function CloseDateTimeFormatter(value, row) {

    var reValue = TransferDate(row.CloseDate);

    return reValue + "<br>" + row.CloseCaus;
}

//建立者-建立日期
function CreateDateTimeFormatter(value, row) {

    var reValue = TransferDateTime(row.CreateDateTime);

    return row.Creator + "<br>" + reValue;
}


function LastModifyDateTimeFormatter(value, row) {

    var reValue = TransferDateTime(row.LastModifyDateTime);

    return row.LastModifyWorker + "<br>" + reValue;
}

