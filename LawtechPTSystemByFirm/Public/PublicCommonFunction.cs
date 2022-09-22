
namespace LawtechPTSystemByFirm.Public
{
    /// <summary>
    /// 取得連線字串 Properties.Settings.Default.DataBaseConnectionString
    /// <para>判斷字串內含有「Data Source=」則不解密; 反之則用H3Operator進行解密</para>
    /// </summary>
    public static class PublicCommonFunction
    {

        public static string GetConnectionString()
        {
            if (Properties.Settings.Default.DataBaseConnectionString != "" && Properties.Settings.Default.DataBaseConnectionString.Contains("Data Source="))
            {
              return   Properties.Settings.Default.DataBaseConnectionString;
            }
            else
            {
                return H3Operator.DBHelper.EncryptorClass.Decrypt(Properties.Settings.Default.DataBaseConnectionString, "@wsx8UHB");
            }
        }
    }
}
