using System.Security.Cryptography;
using System.Text;

namespace WalletApp.BLL.Common
{
    public static class MD5ForPassword
    {
        public static string HashPassword(string password)
        {
            MD5 md = MD5.Create();

            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = md.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
                sb.Append(a.ToString("X2"));
            return Convert.ToString(sb);
        }
    }
}
