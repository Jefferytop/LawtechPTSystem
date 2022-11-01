namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 
    /// </summary>
    public class PublicForm 
    {
        private static Login _Login = null;
        private static MainFrom _MainFrom = null;
        private static SubFrom.SMSsend _SMSsend = null;
        private static SubFrom.PatentWorkerEventFinish _PatentWorkerEventFinish = null;
        private static SubFrom.TrademarkWorkerEventFinish _TrademarkWorkerEventFinish = null;
        private static SubFrom.PTSUpdate _PTSUpdate = null;
        private static SubFrom.MACsetting _MACsetting = null;
        private static SubFrom.OfficialDocument _OfficialDocument = null;
        private static SubFrom.ImportSystemData _ImportSystemData = null;
        private static SubFrom.AttorneyMF _AttorneyMF = null;
        private static SubFrom.AttorneySearchMF _AttorneySearchMF = null;
        private static SubFrom.ApplicantMF _ApplicantMF = null;
        private static SubFrom.ApplicantList _ApplicantList = null;
        private static SubFrom.QPForm _QPForm = null;
        private static SubFrom.ClientFeeMF _ClientFeeMF = null;
        private static SubFrom.SubjectMF _SubjectMF = null;
        private static SubFrom.PetitionMF _PetitionMF = null;
        private static SubFrom.PetitionSearchMF _PetitionSearchMF = null;
        private static SubFrom.ParagraphDetailMF _ParagraphDetailMF = null;
        private static SubFrom.ApplicantSearchMF _ApplicantSearchMF = null;
        private static SubFrom.QPSearchForm _QPSearchForm = null;
        private static SubFrom.AccountingCompany _AccountingCompany = null;
        

        private static SubFrom.UploadFile _UploadFile = null;
        private static SubFrom.AuthorityMF _AuthorityMF = null;
        private static SubFrom.KeyWords _KeyWords = null;
        private static SubFrom.PATMF _PATMF = null;
        private static SubFrom.PatListMF _PatListMF = null;
        private static SubFrom.TrademarkMF _TrademarkMF = null;
        private static SubFrom.PATStatusMF _PATStatusMF = null;
        private static SubFrom.PATFeatureMF _PATFeatureMF = null;
        private static SubFrom.PATNotifyContentMF _PATNotifyContentMF = null;
        private static SubFrom.PATNotifyDueMF _PATNotifyDueMF = null;       
        private static SubFrom.TMTypeMF _TMTypeMF = null;
        private static SubFrom.TMNotifyContentMF _TMNotifyContentMF = null;
        private static SubFrom.TMNotifyDueMF _TMNotifyDueMF = null;
        private static SubFrom.TMStatusMF _TMStatusMF = null;
        private static SubFrom.Triff_PAT _Triff_PAT = null;
        private static SubFrom.Triff_TM _Triff_TM = null;
        private static SubFrom.ComitContentTMF _ComitContentTMF = null;
        private static SubFrom.PatentMF _PatentMF = null;
        private static SubFrom.TMMF _TMMF = null;
        private static SubFrom.PATEventProcess _PATEventProcess = null;
        private static SubFrom.PatFeePhase _PatFeePhase = null;
        private static SubFrom.PATControlEvent _PATControlEvent = null;
        private static SubFrom.PatentStatistics _PatentStatistics = null;
        private static SubFrom.TrademarkClassificationMF _TrademarkClassificationMF = null;
        private static SubFrom.TrademarkEventProcess _TrademarkEventProcess = null;
        private static SubFrom.TrademarkFeePhase _TrademarkFeePhase = null;
        private static SubFrom.TrademarkStyle _TrademarkStyle = null;
        private static SubFrom.TrademarkNotifyEventType _TrademarkNotifyEventType = null;
        private static SubFrom.TrademarkControlEvent _TrademarkControlEvent = null;
        private static SubFrom.TrademarkStatistics _TrademarkStatistics = null;
        private static SubFrom.TMComitContentMF _TMComitContentMF = null;
        private static SubFrom.MailSampleList _MailSampleList = null;
        private static SubFrom.AccountingFeeMF _AccountingFeeMF = null;
        private static SubFrom.AccountingFeeList _AccountingFeeList = null;
        private static SubFrom.AccountingPaymentMF _AccountingPaymentMF = null;
        
        private static SubFrom.OfficePropertyMF _OfficePropertyMF = null;
        private static SubFrom.PatentFeeSearch _PatentFeeSearch = null;
        private static SubFrom.PatentPaymentSearch _PatentPaymentSearch = null;
        private static SubFrom.LegalStatusSet _LegalStatusSet = null;
        private static SubFrom.LegalTypeSet _LegalTypeSet = null;
        private static SubFrom.LegalFeePhase _LegalFeePhase = null;
        private static SubFrom.LegalEventProcess _LegalEventProcess = null;
        private static SubFrom.AccountingCombin _AccountingCombin = null;
        private static SubFrom.NewsList _News = null;
        private static SubFrom.CalendarForm _CalendarForm = null;
        private static SubFrom.LinksMF _LinksMF = null;
        private static SubFrom.DelDataLogMF _DelDataLogMF = null;
        private static SubFrom.EmailLogMF _EmailLogMF = null;
        private static SubFrom.TrademarkFeeSearch _TrademarkFeeSearch = null;       
        private static SubFrom.LoginLog _LoginLog = null;
        private static SubFrom.PatentEventList _PatentEventList = null;
        private static SubFrom.PATControlEventList _PATControlEventList = null;
        private static SubFrom.PATControlFeeList _PATControlFeeList = null;
        private static SubFrom.PATControlYearFeeList _PATControlYearFeeList = null;
        private static SubFrom.PATControlPayment _PATControlPayment = null;
        private static SubFrom.TrademarkControlEventList _TrademarkControlEventList = null;
        private static SubFrom.TrademarkControlFeeList _TrademarkControlFeeList = null;
        private static SubFrom.TrademarkControlPaymentList _TrademarkControlPaymentList = null;
        private static SubFrom.TrademarkControlExtendedFeeList _TrademarkControlExtendedFeeList = null;
        private static SubFrom.TrademarkPaymentSearchList _TrademarkPaymentSearchList = null;
        private static SubFrom.TrademarkFeeSearchList _TrademarkFeeSearchList = null;

        private static SubFrom.PatentPerformanceList _PatentPerformanceList = null;
        private static SubFrom.CountrySetting _CountrySetting = null;

        private static SubFrom.AccountingCombinList _AccountingCombinList = null;

        private static SubFrom.TrademarkEventList _TrademarkEventList = null;
        private static SubFrom.TrademarkPerformanceList _TrademarkPerformanceList = null;

        private static SubFrom.SMSLogsMF _SMSLogsMF = null;

        public MainFrom MainFrom
        {
            get { return _MainFrom; }
            set { _MainFrom = value; }
        }

        /// <summary>
        /// 簡訊發送
        /// </summary>
        public SubFrom.SMSsend SMSsend
        {
            get { return _SMSsend; }
            set { _SMSsend = value; }
        }

        /// <summary>
        /// 入帳公司
        /// </summary>
        public SubFrom.AccountingCompany AccountingCompany
        {
            get { return _AccountingCompany; }
            set { _AccountingCompany = value; }
        }        

        /// <summary>
        /// 簡訊記錄檔
        /// </summary>
        public SubFrom.SMSLogsMF SMSLogsMF
        {
            get { return _SMSLogsMF; }
            set { _SMSLogsMF = value; }
        }

        /// <summary>
        /// 行事曆
        /// </summary>
        public SubFrom.CalendarForm CalendarForm
        {
            get { return _CalendarForm; }
            set { _CalendarForm = value; }
        }

        /// <summary>
        /// 登入頁
        /// </summary>
        public Login Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        /// <summary>
        /// 個人專利完成事件
        /// </summary>
        public SubFrom.PatentWorkerEventFinish PatentWorkerEventFinish
        {
            get { return _PatentWorkerEventFinish; }
            set { _PatentWorkerEventFinish = value; }
        }

        /// <summary>
        /// 個人商標完成事件
        /// </summary>
        public SubFrom.TrademarkWorkerEventFinish TrademarkWorkerEventFinish
        {
            get { return _TrademarkWorkerEventFinish; }
            set { _TrademarkWorkerEventFinish = value; }
        }

        /// <summary>
        /// PTS更新檢查
        /// </summary>
        public SubFrom.PTSUpdate PTSUpdate
        {
            get { return _PTSUpdate; }
            set { _PTSUpdate = value; }
        }

        /// <summary>
        /// MAC位址綁定
        /// </summary>
        public SubFrom.MACsetting MACsetting
        {
            get { return _MACsetting; }
            set { _MACsetting = value; }
        }

        /// <summary>
        /// 官方公文管理
        /// </summary>
        public SubFrom.OfficialDocument OfficialDocument
        {
            get { return _OfficialDocument; }
            set { _OfficialDocument = value; }
        }

        /// <summary>
        /// 匯入系統資料
        /// </summary>
        public SubFrom.ImportSystemData ImportSystemData
        {
            get { return _ImportSystemData; }
            set { _ImportSystemData = value; }
        }

        public SubFrom.TrademarkPerformanceList TrademarkPerformanceList
        {
            get { return _TrademarkPerformanceList; }
            set { _TrademarkPerformanceList = value; }
        }

        public SubFrom.TrademarkEventList TrademarkEventList
        {
            get { return _TrademarkEventList; }
            set { _TrademarkEventList = value; }
        }

        public SubFrom.AccountingCombinList AccountingCombinList
        {
            get { return _AccountingCombinList; }
            set { _AccountingCombinList = value; }
        }

        public SubFrom.OfficePropertyMF OfficePropertyMF
        {
            get { return _OfficePropertyMF; }
            set { _OfficePropertyMF = value; }
        }

        public SubFrom.CountrySetting CountrySetting
        {
            get { return _CountrySetting; }
            set { _CountrySetting = value; }
        }

        public SubFrom.PatentPerformanceList PatentPerformanceList
        {
            get { return _PatentPerformanceList; }
            set { _PatentPerformanceList = value; }
        }

        public SubFrom.TrademarkFeeSearchList TrademarkFeeSearchList
        {
            get { return _TrademarkFeeSearchList; }
            set { _TrademarkFeeSearchList = value; }
        }

        public SubFrom.TrademarkPaymentSearchList TrademarkPaymentSearchList
        {
            get { return _TrademarkPaymentSearchList; }
            set { _TrademarkPaymentSearchList = value; }
        }

        public SubFrom.TrademarkControlFeeList TrademarkControlFeeList
        {
            get { return _TrademarkControlFeeList; }
            set { _TrademarkControlFeeList = value; }
        }

        public SubFrom.TrademarkControlPaymentList TrademarkControlPaymentList
        {
            get { return _TrademarkControlPaymentList; }
            set { _TrademarkControlPaymentList = value; }
        }

        public SubFrom.TrademarkControlExtendedFeeList TrademarkControlExtendedFeeList
        {
            get { return _TrademarkControlExtendedFeeList; }
            set { _TrademarkControlExtendedFeeList = value; }
        }

        public SubFrom.PATControlEventList PATControlEventList
        {
            get { return _PATControlEventList; }
            set { _PATControlEventList = value; }
        }

        public SubFrom.PatentEventList PatentEventList
        {
            get { return _PatentEventList; }
            set { _PatentEventList = value; }
        }

        public SubFrom.PATControlPayment PATControlPayment
        {
            get { return _PATControlPayment; }
            set { _PATControlPayment = value; }
        }

        /// <summary>
        /// 專利年費管制表
        /// </summary>
        public SubFrom.PATControlYearFeeList PATControlYearFeeList
        {
            get { return _PATControlYearFeeList; }
            set { _PATControlYearFeeList = value; }
        }

        public SubFrom.AttorneyMF AttorneyMF
        {
            get { return _AttorneyMF; }
            set { _AttorneyMF = value; }
        }

        /// <summary>
        /// 舊版 不要使用
        /// </summary>
        public SubFrom.AccountingFeeMF AccountingFeeMF
        {
            get { return _AccountingFeeMF; }
            set { _AccountingFeeMF = value; }
        }

        /// <summary>
        /// 應請款項清單表
        /// </summary>
        public SubFrom.AccountingFeeList AccountingFeeList
        {
            get { return _AccountingFeeList; }
            set { _AccountingFeeList = value; }
        }

        /// <summary>
        /// 應付款項清單表
        /// </summary>
        public SubFrom.AccountingPaymentMF AccountingPaymentMF
        {
            get { return _AccountingPaymentMF; }
            set { _AccountingPaymentMF = value; }
        }

        public SubFrom.AttorneySearchMF AttorneySearchMF
        {
            get { return _AttorneySearchMF; }
            set { _AttorneySearchMF = value; }
        }

        public SubFrom.QPForm QPForm
        {
            get { return _QPForm; }
            set { _QPForm = value; }
        }

        public SubFrom.ApplicantMF ApplicantMF
        {
            get { return _ApplicantMF; }
            set { _ApplicantMF = value; }
        }

        /// <summary>
        /// 客戶資料列表(申請人)
        /// </summary>
        public SubFrom.ApplicantList ApplicantList
        {
            get { return _ApplicantList; }
            set { _ApplicantList = value; }
        }

        public SubFrom.ApplicantSearchMF ApplicantSearchMF
        {
            get { return _ApplicantSearchMF; }
            set { _ApplicantSearchMF = value; }
        }

        /// <summary>
        /// 客戶報價處理
        /// </summary>
        public SubFrom.ClientFeeMF ClientFeeMF
        {
            get { return _ClientFeeMF; }
            set { _ClientFeeMF = value; }
        }

        public SubFrom.SubjectMF SubjectMF
        {
            get { return _SubjectMF; }
            set { _SubjectMF = value; }
        }

        public SubFrom.PetitionMF PetitionMF
        {
            get { return _PetitionMF; }
            set { _PetitionMF = value; }
        }

        public SubFrom.PetitionSearchMF PetitionSearchMF
        {
            get { return _PetitionSearchMF; }
            set { _PetitionSearchMF = value; }
        }

        public SubFrom.ParagraphDetailMF ParagraphDetailMF
        {
            get { return _ParagraphDetailMF; }
            set { _ParagraphDetailMF = value; }
        }
        public SubFrom.QPSearchForm QPSearchForm
        {
            get { return _QPSearchForm; }
            set { _QPSearchForm = value; }
        }
        //public SubFrom.PrintLabelMF PrintLabelMF
        //{
        //    get { return _PrintLabelMF; }
        //    set { _PrintLabelMF = value; }
        //}

        /// <summary>
        /// 知識管理
        /// </summary>
        public SubFrom.UploadFile UploadFile
        {
            get { return _UploadFile; }
            set { _UploadFile = value; }
        }

        public SubFrom.AuthorityMF AuthorityMF
        {
            get { return _AuthorityMF; }
            set { _AuthorityMF = value; }
        }

        public SubFrom.KeyWords KeyWords
        {
            get { return _KeyWords; }
            set { _KeyWords = value; }
        }


        public SubFrom.PATMF PATMF
        {
            get { return _PATMF; }
            set { _PATMF = value; }
        }

        public SubFrom.PatListMF PatListMF
        {
            get { return _PatListMF; }
            set { _PatListMF = value; }
        }

        public SubFrom.PatentStatistics PatentStatistics
        {
            get { return _PatentStatistics; }
            set { _PatentStatistics = value; }
        }

        public SubFrom.TrademarkMF TrademarkMF
        {
            get { return _TrademarkMF; }
            set { _TrademarkMF = value; }
        }

       
        public SubFrom.PATStatusMF PATStatusMF
        {
            get { return _PATStatusMF; }
            set { _PATStatusMF = value; }
        }
        
        public SubFrom.PATFeatureMF PATFeatureMF
        {
            get { return _PATFeatureMF; }
            set { _PATFeatureMF = value; }
        }

       
        public SubFrom.PATNotifyContentMF PATNotifyContentMF
        {
            get { return _PATNotifyContentMF; }
            set { _PATNotifyContentMF = value; }
        }
       
        public SubFrom.PATNotifyDueMF PATNotifyDueMF
        {
            get { return _PATNotifyDueMF; }
            set { _PATNotifyDueMF = value; }
        }
             
        public SubFrom.TMTypeMF TMTypeMF
        {
            get { return _TMTypeMF; }
            set { _TMTypeMF = value; }
        }
                
        public SubFrom.TMNotifyContentMF TMNotifyContentMF
        {
            get { return _TMNotifyContentMF; }
            set { _TMNotifyContentMF = value; }
        }
        
        public SubFrom.TMNotifyDueMF TMNotifyDueMF
        {
            get { return _TMNotifyDueMF; }
            set { _TMNotifyDueMF = value; }
        }
        
        public SubFrom.TMStatusMF TMStatusMF
        {
            get { return _TMStatusMF; }
            set { _TMStatusMF = value; }
        }
        
        public SubFrom.Triff_PAT Triff_PAT
        {
            get { return _Triff_PAT; }
            set { _Triff_PAT = value; }
        }
        
        public SubFrom.Triff_TM Triff_TM
        {
            get { return _Triff_TM; }
            set { _Triff_TM = value; }
        }

        /// <summary>
        /// 專利--事件內容
        /// </summary>
        public SubFrom.ComitContentTMF ComitContentTMF
        {
            get { return _ComitContentTMF; }
            set { _ComitContentTMF = value; }
        }

        public SubFrom.PatentMF PatentMF
        {
            get { return _PatentMF; }
            set { _PatentMF = value; }
        }

        public SubFrom.TMMF TMMF
        {
            get { return _TMMF; }
            set { _TMMF = value; }
        }

        public SubFrom.PATEventProcess PATEventProcess
        {
            get { return _PATEventProcess; }
            set { _PATEventProcess = value; }
        }

        public SubFrom.PatFeePhase PatFeePhase
        {
            get { return _PatFeePhase; }
            set { _PatFeePhase = value; }
        }

        public SubFrom.PATControlEvent PATControlEvent
        {
            get { return _PATControlEvent; }
            set { _PATControlEvent = value; }
        }

        public SubFrom.PATControlFeeList PATControlFeeList
        {
            get { return _PATControlFeeList; }
            set { _PATControlFeeList = value; }
        }

        public SubFrom.TrademarkClassificationMF TrademarkClassificationMF
        {
            get { return _TrademarkClassificationMF; }
            set { _TrademarkClassificationMF = value; }
        }

        public SubFrom.TrademarkEventProcess TrademarkEventProcess
        {
            get { return _TrademarkEventProcess; }
            set { _TrademarkEventProcess = value; }
        }

        public SubFrom.TrademarkFeePhase TrademarkFeePhase
        {
            get { return _TrademarkFeePhase; }
            set { _TrademarkFeePhase = value; }
        }

        public SubFrom.TrademarkStyle TrademarkStyle
        {
            get { return _TrademarkStyle; }
            set { _TrademarkStyle = value; }
        }

        public SubFrom.TrademarkNotifyEventType TrademarkNotifyEventType
        {
            get { return _TrademarkNotifyEventType; }
            set { _TrademarkNotifyEventType = value; }
        }

        public SubFrom.TrademarkControlEvent TrademarkControlEvent
        {
            get { return _TrademarkControlEvent; }
            set { _TrademarkControlEvent = value; }
        }

        public SubFrom.TrademarkControlEventList TrademarkControlEventList
        {
            get { return _TrademarkControlEventList; }
            set { _TrademarkControlEventList = value; }
        }

        public SubFrom.TrademarkStatistics TrademarkStatistics
        {
            get { return _TrademarkStatistics; }
            set { _TrademarkStatistics = value; }
        }


        public SubFrom.TMComitContentMF TMComitContentMF
        {
            get { return _TMComitContentMF; }
            set { _TMComitContentMF = value; }
        }

        public SubFrom.MailSampleList MailSampleList
        {
            get { return _MailSampleList; }
            set { _MailSampleList = value; }
        }

        

        public SubFrom.PatentFeeSearch PatentFeeSearch
        {
            get { return _PatentFeeSearch; }
            set { _PatentFeeSearch = value; }
        }


        public SubFrom.PatentPaymentSearch PatentPaymentSearch
        {
            get { return _PatentPaymentSearch; }
            set { _PatentPaymentSearch = value; }
        }

        public SubFrom.LegalStatusSet LegalStatusSet
        {
            get { return _LegalStatusSet; }
            set { _LegalStatusSet = value; }
        }


        public SubFrom.LegalTypeSet LegalTypeSet
        {
            get { return _LegalTypeSet; }
            set { _LegalTypeSet = value; }
        }

        public SubFrom.LegalFeePhase LegalFeePhase
        {
            get { return _LegalFeePhase; }
            set { _LegalFeePhase = value; }
        }

        public SubFrom.LegalEventProcess LegalEventProcess
        {
            get { return _LegalEventProcess; }
            set { _LegalEventProcess = value; }
        }

        public SubFrom.AccountingCombin AccountingCombin
        {
            get { return _AccountingCombin; }
            set { _AccountingCombin = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SubFrom.NewsList News
        {
            get { return _News; }
            set { _News = value; }
        }

        public SubFrom.LinksMF LinksMF
        {
            get { return _LinksMF; }
            set { _LinksMF = value; }
        }

        public SubFrom.DelDataLogMF DelDataLogMF
        {
            get { return _DelDataLogMF; }
            set { _DelDataLogMF = value; }
        }

        public SubFrom.EmailLogMF EmailLogMF
        {
            get { return _EmailLogMF; }
            set { _EmailLogMF = value; }
        }

        public SubFrom.LoginLog LoginLog
        {
            get { return _LoginLog; }
            set { _LoginLog = value; }
        }

        public SubFrom.TrademarkFeeSearch TrademarkFeeSearch
        {
            get { return _TrademarkFeeSearch; }
            set { _TrademarkFeeSearch = value; }
        }
    }    
}
