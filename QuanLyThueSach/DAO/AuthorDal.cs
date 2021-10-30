using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class AuthorDal
    {
        private readonly string _connectionString;

        private static AuthorDal _instance;

        public static AuthorDal Instance()
        {
            if (_instance == null)
            {
                _instance = new AuthorDal();
            }
            return _instance;
        }
        public AuthorDal()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<BaseEntity> LoadAuthorsToCombobox()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getAuthorsToCombobox", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<BaseEntity> authors = new List<BaseEntity>();

                    if (data.Rows.Count == 0) return authors;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var author = new BaseEntity(row);

                        authors.Add(author);
                    }

                    return authors;

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
