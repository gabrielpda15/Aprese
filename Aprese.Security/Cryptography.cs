using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Aprese.Security
{
    public sealed class Cryptography
    {
        private UTF8Encoding UTF8 { get; }

        public Cryptography()
        {
            UTF8 = new UTF8Encoding();
        }

        public string GenerateHash(string value, int depth = 5)
        {
            var tempResult = UTF8.GetBytes(value);

            using (var hashProvider = MD5.Create())
            {
                for (int i = 0; i < depth; i++)
                {
                    tempResult = hashProvider.ComputeHash(tempResult);
                }
            }

            return Convert.ToBase64String(tempResult);
        }

        public string Encrypt(string message, string phrase)
        {
            var dataToCrypt = UTF8.GetBytes(message);
            var result = Crypt(dataToCrypt, phrase, x => x.CreateEncryptor());
            return Convert.ToBase64String(result);
        }

        public string Decrypt(string message, string phrase)
        {
            var dataToCrypt = Convert.FromBase64String(message);
            var result = Crypt(dataToCrypt, phrase, x => x.CreateDecryptor());
            return Convert.ToBase64String(result);
        }        

        private byte[] Crypt(byte[] message, string phrase, Func<TripleDES, ICryptoTransform> func)
        {
            ICryptoTransform crypto;

            using (var TDESAlgorithm = TripleDES.Create())
            {
                using (var hashProvider = MD5.Create())
                {
                    TDESAlgorithm.Key = hashProvider.ComputeHash(UTF8.GetBytes(phrase));
                }
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;
                crypto = func.Invoke(TDESAlgorithm);
            }

            return crypto.TransformFinalBlock(message, 0, message.Length);
        }
    }
}
