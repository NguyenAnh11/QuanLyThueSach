using System;
using System.Text;
using System.Security.Cryptography;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class AccountDAO
    {
        private static AccountDAO _instance;
        public static AccountDAO Instance()
        {
            if(_instance == null)
            {
                _instance = new AccountDAO();
            }
            return _instance;
        }
        public Person Login(string username, string password)
        {
            string query = "exec sp_login @username , @password";

            //string hashPassword = HashPassword(password);

            var data = DataProvider.Instance().ExcuteQuery(query, new object[] { username, password });

            if (data.Rows.Count != 1) return null;

            var row = data.Rows[0];

            int role = (int)row["role"];

            Person person = new Employee(row);
            return person;
        }

        public string HashPassword(string password)
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
