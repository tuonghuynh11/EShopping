using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.PasswordEncode
{
    public class EncodeString
    {
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static string Base64Encode(string input)
        {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(textBytes);
        }

        public static string EncodePass(string input)
        {
            return EncodeString.Base64Encode(EncodeString.MD5Hash(input));
        }
    }
}
