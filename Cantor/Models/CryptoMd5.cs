using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor.Models
{
    class CryptoMd5
    {
        private string value { get; set; }
        private string crypto { get; set; }
        public CryptoMd5() { }

        public string hash( String data)
        {
            value = data;

            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(data);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder cryptPass = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                cryptPass.Append(hash[i].ToString("X2"));
            }
            crypto = cryptPass.ToString();

            return crypto;
        }
    }
}
