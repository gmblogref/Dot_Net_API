using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GMB.CryptoService
{
    public abstract class BaseCryptoService
    {
        private const string _SECURITYKEY = "3502A462D4A614E64E238";

        /// <summary>
        /// Using the security key return a byte array hash
        /// </summary>
        /// <returns></returns>
        protected byte[] GetSecurityKeyArray()
        {
            MD5CryptoServiceProvider mD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = mD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_SECURITYKEY));
            mD5CryptoService.Clear();
            
            return securityKeyArray;
        }

        protected TripleDESCryptoServiceProvider GetCryptoServiceProvider(byte[] securityKeyArray)
        {
            var tripleDESCryptoService = new TripleDESCryptoServiceProvider();
            tripleDESCryptoService.Key = securityKeyArray;
            tripleDESCryptoService.Mode = CipherMode.ECB;
            tripleDESCryptoService.Padding = PaddingMode.PKCS7;

            return tripleDESCryptoService;
        }
    }
}
