using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyThueSach.DAO
{
    public class DataProvider
    {
        private static DataProvider _instance;
        private string _connectionString { get; set; }
        public static DataProvider Instance()
        {
            if(_instance == null)
            {
                _instance = new DataProvider();
            }
            return _instance;
        }
        public DataProvider()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public DataTable ExcuteQuery(string query, object[] obj)
        {
            var data = new DataTable();
           
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    string[] parameters = query.Split(' ');
                    int index = 0;
                    foreach (var param in parameters)
                    {
                        if (param.StartsWith("@"))
                        {
                            command.Parameters.AddWithValue(param, obj[index]);
                            index += 1;
                        }
                    }

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                } catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
            return data;
        }
        public int ExcuteNonQuery(string query, object[] obj)
        {
            int rows = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    string[] parameters = query.Split(' ');
                    int index = 0;
                    foreach (var param in parameters)
                    {
                        if (param.StartsWith("@"))
                        {
                            var value = obj[index];
                            command.Parameters.AddWithValue(param, value);
                            index += 1;
                        }
                    }

                    rows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
            return rows;
        }

        public object ExecuteScalarQuery(string query, object[] obj)
        {
            object rows = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                string[] parameters = query.Split(' ');
                int index = 0;
                foreach (var param in parameters)
                {
                    if (param.StartsWith("@"))
                    {
                        command.Parameters.AddWithValue(param, obj[index]);
                        index += 1;
                    }
                }

                rows = (int)command.ExecuteScalar();

                connection.Close();
            }
            return rows;
        }
    }
}
