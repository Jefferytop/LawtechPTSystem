
namespace LawtechPTSystem.Public
{
    public struct CountryKindClass
    {
        /// <summary>
        /// 國別代碼
        /// </summary>
        public string CountrySymbol
        { get; set; }

        /// <summary>
        /// 國別名稱
        /// </summary>
        public string Country
        { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        public string KindSN
        { get; set; }


        /// <summary>
        /// 種類名稱
        /// </summary>
        public string Kind
        { get; set; }

        /// <summary>
        /// 是否為大實體; true:是 ;false:否
        /// </summary>
        public bool LargeEntity
        { get; set; }

        public string CountrySymbol_KindSN
        {
            get
            {
                return CountrySymbol + "_" + KindSN;
            }
        }


        public string CountryName_KindName        
        {
            get {
                return Country + "-" + Kind;
            } 
        }
    }
}
