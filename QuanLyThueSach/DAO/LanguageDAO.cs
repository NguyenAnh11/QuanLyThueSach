using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class LanguageDAO
    {
        private readonly string _connectionString;
        private static LanguageDAO _instance;
        public static LanguageDAO Instance()
        {
            if (_instance == null)
            {
                _instance = new LanguageDAO();
            }
            return _instance;
        }
        public LanguageDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<LanguageBook> GetLanguageBooks()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getLanguageBooks", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<LanguageBook> languageBooks = new List<LanguageBook>();

                    if (data.Rows.Count == 0) return languageBooks;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var languageBook = new LanguageBook(row);

                        languageBooks.Add(languageBook);
                    }

                    return languageBooks;

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
