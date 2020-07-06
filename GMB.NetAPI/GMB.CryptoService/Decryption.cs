using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMB.CryptoService
{
    public class Decryption : BaseCryptoService
    {
        /// <summary>
        /// Decrypt the string coming in and return it
        /// https://www.codeguru.com/csharp/csharp/cs_misc/security/triple-des-encryption-and-decryption-in-c.html
        /// </summary>
        /// <param name="textToDecrypt"></param>
        /// <returns></returns>
        public string Decrypt(string textToDecrypt)
        {
            var tripleDESCryptoService = GetCryptoServiceProvider(GetSecurityKeyArray());
            var crytpoTransform = tripleDESCryptoService.CreateDecryptor();

            byte[] resultArray = crytpoTransform.TransformFinalBlock(Convert.FromBase64String(textToDecrypt), 0, Convert.FromBase64String(textToDecrypt).Length);

            tripleDESCryptoService.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
