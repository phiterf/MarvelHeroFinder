using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TesteAcerto.Utils
{
    public static class Hash
    {
        public static String GenerateMD5(String str)
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte[] hashBytes = md5.ComputeHash(bytes);

            return BitConverter.ToString(hashBytes).ToLower().Replace("-", "");
        }
    }
}