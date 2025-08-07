using System;
using System.Security.Cryptography;
using System.Text;

namespace WS_SistemaVenta.Tools
{
    public class Encrypt
    {
        public static string GetSHA256(string str)
        {
            if(str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
