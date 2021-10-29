using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class StatusBookDAO
    {
        private readonly string _connectionString;
        private static StatusBookDAO _instance;
        public static StatusBookDAO Instance()
        {
            if (_instance == null)
            {
                _instance = new StatusBookDAO();
            }
            return _instance;
        }
        public StatusBookDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<StatusBook> GetStatusBooks()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getStatusBooks", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<StatusBook> statusBooks = new List<StatusBook>();

                    if (data.Rows.Count == 0) return statusBooks;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var statusBook = new StatusBook(row);

                        statusBooks.Add(statusBook);
                    }

                    return statusBooks;

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
        }
    }
}
