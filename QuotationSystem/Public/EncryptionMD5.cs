using System;
using System.Security.Cryptography;
using System.Text;

namespace LawtechPTSystem.Public
{
    public class EncryptionMD5
    {
        /// <summary>
        /// 加密字串
        /// </summary>
        /// <param name="strSource">要加密的字串</param>
        /// <param name="key">金鑰</param>
        /// <returns></returns>
        public static string Encryption(string strSource, string key)
        {
            byte[] Original = Encoding.Default.GetBytes(strSource);//將來源字串轉為byte[] 
            byte[] SaltValue = Encoding.Default.GetBytes(key);//將Salted Value轉為byte[] 
            byte[] ToSalt = new byte[Original.Length + SaltValue.Length]; //宣告新的byte[]來儲存加密後的值 
            Original.CopyTo(ToSalt, 0);//將來源字串複製到新byte[] 
            SaltValue.CopyTo(ToSalt, Original.Length);//將Salted Value複製到新byte[] 
            MD5 st = MD5.Create();//使用MD5 
            byte[] SaltPWD = st.ComputeHash(ToSalt);//進行加密 
            byte[] PWD = new byte[SaltPWD.Length + SaltValue.Length];//宣告新byte[]儲存加密及Salted的值 
            SaltPWD.CopyTo(PWD, 0);//將加密後的值複製到新byte[] 
            SaltValue.CopyTo(PWD, SaltPWD.Length);//將Salted Value複製到新byte[] 
            string ReValue = Convert.ToBase64String(PWD);//顯示Salted Hash後的字串

            return ReValue;
        }

    }
}
