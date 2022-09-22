using System;
using System.Data;

namespace LawtechPTSystemByFirm
{
    /// <summary>
    /// 權限列舉定義
    /// </summary>
    [FlagsAttribute]
    enum PermissionTypes
    {
        None = 0,
        View = 1, //檢視
        Create = 2, //新增
        Modify = 4, //修改
        Delete = 8, //刪除
        Upload = 16, //上傳檔案
        Download = 32, //開啟檔案
        Export = 64, //匯出
        All = View | Modify | Delete | Create | Upload | Download | Export
    }

    #region 驗證型態列舉 VerificationAD.cs
    /// <summary>
    /// 驗證型態列舉
    /// </summary>
    public enum ValidType
    {
        /// <summary>
        /// 網域
        /// </summary>
        Domain = 1,
        /// <summary>
        /// 機器
        /// </summary>
        Machine = 2,
        /// <summary>
        /// 應用程式
        /// </summary>
        ApplicationDirectory = 3
    }
    #endregion

    class UserPermissionForm
    {
        private PermissionTypes Permissions = PermissionTypes.None;
        int _WorkerKEY = 0;
        string _programSymbol = "";

        /// <summary>
        /// 取得指定使用者(WorkerKEY)對特定表單(ProgramSymbol)的權限
        /// </summary>
        /// <param name="WorkerKEY">登入者的Key</param>
        /// <param name="ProgramSymbol">程式代碼</param>
        public UserPermissionForm(int WorkerKEY, string ProgramSymbol)
        {
            _WorkerKEY = WorkerKEY;
            _programSymbol = ProgramSymbol;
            GetPermissionByUser(WorkerKEY, ProgramSymbol);
        }

        /// <summary>
        /// 取得指定使用者(WorkerKEY)對特定表單(ProgramSymbol)的權限
        /// </summary>
        /// <param name="WorkerKEY">登入者的Key</param>
        public UserPermissionForm(int WorkerKEY)
        {
            _WorkerKEY = WorkerKEY;
        }

        /// <summary>
        /// 
        /// </summary>
        public PermissionTypes UserPermission
        {
            get { return Permissions; }
        }

        /// <summary>
        /// 特定表單(ProgramSymbol);異動時會自動重新取得權限
        /// </summary>
        public string ProgramSymbol
        {
            get { return _programSymbol; }
            set
            {
                if (_programSymbol != value)
                {
                    _programSymbol = value;
                    GetPermissionByUser(_WorkerKEY, _programSymbol);
                }
            }
        }

        /// <summary>
        /// 登入者的Key
        /// </summary>
        public int WorkerKEY
        {
            get { return _WorkerKEY; }
            set { _WorkerKEY = value; }
        }

        /// <summary>
        /// 取得指定user的對特定表單(ProgramSymbol)的權限
        /// </summary>
        /// <param name="iWorkerKEY">登入者的Key</param>
        /// <param name="ProgramSymbol"></param>
        public void GetPermissionByUser(int iWorkerKEY, string ProgramSymbol)
        {
            string getPermission = string.Format(
               @"SELECT     ProgramT.ProgramKey, ProgramT.ProgramName, ProgramT.[Description],
               (SELECT     SearchAuthority
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {1} ) )AS SearchAuthority ,
                (SELECT     AuthorizeCreate
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeCreate ,
                (SELECT     AuthorizeModify
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeModify ,
                (SELECT     AuthorizeDelete
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeDelete ,
                 (SELECT     AuthorizeUpload
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeUpload ,
                 (SELECT     AuthorizeDownload
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeDownload ,
                (SELECT     AuthorizeExport
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeExport 
                FROM      ProgramT
                WHERE     (ProgramT.IsOpen = 'True') AND (ProgramT.ProgramSymbol = '{0}' )  order by ProgramT.Sort", ProgramSymbol, iWorkerKEY.ToString());

            Public.DLL db = new Public.DLL();
            DataTable dtUserPermission = db.SqlDataAdapterDataTable(getPermission);
            PermissionTypes myPermission = PermissionTypes.None;
            if (dtUserPermission.Rows.Count == 1)
            {
                if (dtUserPermission.Rows[0]["SearchAuthority"] != System.DBNull.Value && (bool)dtUserPermission.Rows[0]["SearchAuthority"])
                    myPermission = myPermission | PermissionTypes.View;

                if (dtUserPermission.Rows[0]["AuthorizeCreate"] != System.DBNull.Value && (bool)dtUserPermission.Rows[0]["AuthorizeCreate"])
                    myPermission = myPermission | PermissionTypes.Create;

                if (dtUserPermission.Rows[0]["AuthorizeModify"] != System.DBNull.Value && (bool)dtUserPermission.Rows[0]["AuthorizeModify"])
                    myPermission = myPermission | PermissionTypes.Modify;

                if (dtUserPermission.Rows[0]["AuthorizeDelete"] != System.DBNull.Value && (bool)dtUserPermission.Rows[0]["AuthorizeDelete"])
                    myPermission = myPermission | PermissionTypes.Delete;

                if (dtUserPermission.Rows[0]["AuthorizeUpload"] != System.DBNull.Value && (bool)dtUserPermission.Rows[0]["AuthorizeUpload"])
                    myPermission = myPermission | PermissionTypes.Upload;

                if (dtUserPermission.Rows[0]["AuthorizeDownload"] != System.DBNull.Value && (bool)dtUserPermission.Rows[0]["AuthorizeDownload"])
                    myPermission = myPermission | PermissionTypes.Download;

                if (dtUserPermission.Rows[0]["AuthorizeExport"] != System.DBNull.Value && (bool)dtUserPermission.Rows[0]["AuthorizeExport"])
                    myPermission = myPermission | PermissionTypes.Export;
            }
            else
            {
                myPermission = PermissionTypes.None;
            }

            Permissions = myPermission;
        }

        /// <summary>
        /// 取得指定user所有的功能清單
        /// </summary>
        /// <param name="WorkerKEY">登入者的Key</param>
        /// <returns></returns>
        public DataTable GetPermissionByUserFormList(int WorkerKEY)
        {
            string getPermission = string.Format(
                @"SELECT     ProgramT.ProgramKey, ProgramT.ProgramName, ProgramT.[Description],
               (SELECT     SearchAuthority
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {0} ) )AS SearchAuthority ,
                (SELECT     AuthorizeCreate
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {0} ) )AS AuthorizeCreate ,
                (SELECT     AuthorizeModify
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY ={0} ) )AS AuthorizeModify ,
                (SELECT     AuthorizeDelete
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {0}) )AS AuthorizeDelete ,
                 (SELECT     AuthorizeUpload
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {0} ) )AS AuthorizeUpload ,
                 (SELECT     AuthorizeDownload
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY ={0}) )AS AuthorizeDownload ,
                (SELECT     AuthorizeExport
                FROM     WorkerProgramT 
                WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {0} ) )AS AuthorizeExport 
                FROM      ProgramT
                WHERE     (ProgramT.IsOpen = 'True') order by ProgramT.Sort", WorkerKEY.ToString());
            Public.DLL db = new Public.DLL();
            DataTable PermissionData = db.SqlDataAdapterDataTable(getPermission);
            return PermissionData;
        }

        /// <summary>
        /// 取得指定user某一個權限的所有功能清單
        /// </summary>
        /// <param name="WorkerKEY">登入者的Key</param>
        /// <param name="userPermission">某一個權限</param>
        /// <returns></returns>
        public DataTable GetPermissionByUserFormList(int WorkerKEY, PermissionTypes userPermission)
        {
            string PermissionName = "Authorize" + Enum.GetName(typeof(PermissionTypes), userPermission);
            string getPermission = string.Format(
               @"SELECT     ProgramT.ProgramKey, ProgramT.ProgramName, ProgramT.FunctionDescription,
               (SELECT     {1}
                FROM     WorkerProgramT 
                 WHERE      (ProgramT.ProgramKEY = WorkerProgramT.ProgramKEY)AND (WorkerKEY = {0} ) )AS {1}
                FROM      ProgramT
                WHERE     (ProgramT.IsEnabled = 'True') order by ProgramT.Sort", WorkerKEY.ToString(), PermissionName);
            Public.DLL db = new Public.DLL();
            DataTable PermissionData = db.SqlDataAdapterDataTable(getPermission);
            return PermissionData;
        }




    }
}
