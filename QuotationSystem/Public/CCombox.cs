
namespace LawtechPTSystem.Public
{
    class CCombox
    {
        private string _showstring;
        private string _valueString;
        private string _string1;
        private int _ListMode;
        private string _SelectString;
        private string _SelectValue;

        /// <summary>
        /// 主ComboBox的 Select String
        /// </summary>
        public string ShowString
        {
            get {
                if (_showstring != null)
                {
                    return _showstring;
                }
                else
                {
                    return "";
                }
            }
            set {
                _showstring = value;
            }
        }

        /// <summary>
        /// 主ComboBox的 Select Value
        /// </summary>
        public string ValueString
        {
            get
            {
                if (_valueString != null)
                {
                    return _valueString;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                _valueString = value;
            }
        }

        /// <summary>
        /// 該項目的查詢語法
        /// </summary>
        public string strSQL
        {
            get
            {
                if (_string1 != null)
                {
                    return _string1;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                _string1 = value;
            }
        }

        /// <summary>
        /// ComboBox的模式
        /// </summary>
        public int ListMode
        {
            get
            {
                return _ListMode;
            }
            set
            {
                _ListMode = value;
            }
        }

        /// <summary>
        /// 連動的ComboBox Select String 
        /// </summary>
        public string SelectString
        {
            get
            {
                if (_SelectString != null)
                {
                    return _SelectString;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                _SelectString = value;
            }
        }

        /// <summary>
        /// 連動的ComboBox Select Value
        /// </summary>
        public string SelectValue
        {
            get
            {
                if (_SelectValue != null)
                {
                    return _SelectValue;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                _SelectValue = value;
            }
        }

       
    }
}


