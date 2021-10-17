using System;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace QuanLyThueSach.DAO
{
    public class AccountDAO
    {
        public static DataTable Login(string username, string password)
        {
            string query = "exec sp_login @username , @password";

            string hashPassword = HashPassword(password);

            var data = DataProvider.Instance().ExcuteQuery(query, new object[] { username, hashPassword });

            return data;
        }

        public static string HashPassword(string password)
        {
            var rng = new RNGCryptoServiceProvider();

            byte[] saltBytes = new byte[36];
            rng.GetBytes(saltBytes);

            string salt = Convert.ToBase64String(saltBytes);

            byte[] passwordAndSaltBytes = Encoding.UTF8.GetBytes(password + salt);

            byte[] hashBytes = SHA256Managed.Create().ComputeHash(passwordAndSaltBytes);

            string hashPassword = Convert.ToBase64String(hashBytes);

            return hashPassword;
        }
    }
}
