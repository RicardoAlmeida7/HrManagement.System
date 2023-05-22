using System.Security.Cryptography;
using System.Text;

namespace HrManagement.Security.Cryptography
{
    public class Encrypt
    {
        private const string CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateRandomString(int length)
        {

            using (var rng = new RNGCryptoServiceProvider())
            {
                var sb = new StringBuilder(length);
                var buffer = new byte[sizeof(uint)];
                while (sb.Length < length)
                {
                    rng.GetBytes(buffer);
                    uint num = BitConverter.ToUInt32(buffer, 0);
                    sb.Append(CHARACTERS[(int)(num % (uint)CHARACTERS.Length)]);
                }
                return sb.ToString();
            }
        }

        public static string GenerateSHA256Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
