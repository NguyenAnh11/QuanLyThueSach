using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class LanguageDal
    {
        private readonly string _connectionString;

        private static LanguageDal _instance;

        public static LanguageDal Instance()
        {
            if (_instance == null)
            {
                _instance = new LanguageDal();
            }
            return _instance;
        }
        public LanguageDal()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<BaseEntity> LoadLanguagesToCombobox()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getLanguagesToCombobox", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<BaseEntity> languages = new List<BaseEntity>();

                    if (data.Rows.Count == 0) return languages;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var language = new BaseEntity(row);

                        languages.Add(language);
                    }

                    return languages;

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
