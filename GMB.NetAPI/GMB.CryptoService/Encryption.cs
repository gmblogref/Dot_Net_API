using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GMB.CryptoService
{
    public class Encryption : BaseCryptoService
    {
        /// <summary>
        /// Encrypt the string coming in and return it
        /// https://www.codeguru.com/csharp/csharp/cs_misc/security/triple-des-encryption-and-decryption-in-c.html
        /// </summary>
        /// <param name="valueToEncrypt"></param>
        /// <returns></returns>
        public string Encrypt(string textToEncrypt)
        {
            var tripleDESCryptoService = GetCryptoServiceProvider(GetSecurityKeyArray());
            var crytpoTransform = tripleDESCryptoService.CreateEncryptor();

            byte[] resultArray = crytpoTransform.TransformFinalBlock(UTF8Encoding.UTF8.GetBytes(textToEncrypt), 0, UTF8Encoding.UTF8.GetBytes(textToEncrypt).Length);

            tripleDESCryptoService.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
