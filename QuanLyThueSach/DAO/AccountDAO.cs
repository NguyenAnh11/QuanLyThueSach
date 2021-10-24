using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using QuanLyThueSach.Model;
using QuanLyThueSach.DTO.Account;
using QuanLyThueSach.DTO.Staff;

namespace QuanLyThueSach.DAO
{
    public class AccountDAO
    {
        private string _connectionString { get; set; }
        private static AccountDAO _instance;
        public static AccountDAO Instance()
        {
            if(_instance == null)
            {
                _instance = new AccountDAO();
            }
            return _instance;
        }
        public AccountDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public Person Login(LoginDto dto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_login", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", dto.Username);
                    command.Parameters.AddWithValue("@password", dto.Password);

                    var adataper = new SqlDataAdapter(command);

                    var data = new DataTable();

                    adataper.Fill(data);

                    var row = data.Rows[0];

                    var person = new Employee(row);

                    return person;

                } catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public int UpdatePassword(int userId, PasswordUpdateDto dto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var commandCheckExistAccount = new SqlCommand("sp_checkAccountExistByIdAndPassword", connection);

                    commandCheckExistAccount.CommandType = CommandType.StoredProcedure;

                    commandCheckExistAccount.Parameters.AddWithValue("@id", userId);
                    commandCheckExistAccount.Parameters.AddWithValue("@password", dto.OldPass);

                    bool exist = (int)commandCheckExistAccount.ExecuteScalar() == 1 ? true : false;

                    if (!exist) throw new Exception("Mật khẩu không khớp");

                    var commandChangePassword = new SqlCommand("sp_changePassword", connection);

                    commandChangePassword.CommandType = CommandType.StoredProcedure;

                    commandChangePassword.Parameters.AddWithValue("@id", userId);
                    commandChangePassword.Parameters.AddWithValue("@password", dto.NewPass);

                    int row = commandChangePassword.ExecuteNonQuery();

                    return row;
                } catch(Exception ex)
                {
                    throw ex;
                } finally
                {
                    connection.Close();
                }
            }
        }
        public int UpdateProfile(EmployeeUpdateByStaffDto dto)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "sp_update_profile_by_staff";

                    var command = new SqlCommand(query, connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", dto.Id);
                    command.Parameters.AddWithValue("@display_name", dto.Username);
                    command.Parameters.AddWithValue("@birthday", dto.Birthday.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@gender", dto.Gender);
                    command.Parameters.AddWithValue("@address", string.IsNullOrEmpty(dto.Address) ? (object)DBNull.Value : dto.Address);
                    command.Parameters.AddWithValue("@phone", dto.Phone);
                    command.Parameters.AddWithValue("@avatar", dto.Avatar);

                    int row = command.ExecuteNonQuery();

                    return row;

                } catch(Exception ex)
                {
                    throw ex;
                } finally
                {
                    connection.Close();
                }
            }
        }
    }
}
