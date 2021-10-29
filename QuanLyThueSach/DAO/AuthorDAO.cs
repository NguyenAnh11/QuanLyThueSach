using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class AuthorDAO
    {
        private readonly string _connectionString;
        private static AuthorDAO _instance;
        public static AuthorDAO Instance()
        {
            if (_instance == null)
            {
                _instance = new AuthorDAO();
            }
            return _instance;
        }
        public AuthorDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<Author> GetAuthors()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getAuthors", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<Author> authors = new List<Author>();

                    if (data.Rows.Count == 0) return authors;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var author = new Author(row);

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
