using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class CategoryDAO
    {
        private readonly string _connectionString;
        private static CategoryDAO _instance;
        public static CategoryDAO Instance()
        {
            if(_instance == null)
            {
                _instance = new CategoryDAO();
            }
            return _instance;
        }
        public CategoryDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<Category> GetCategories()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getCategories", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<Category> categories = new List<Category>();

                    if (data.Rows.Count == 0) return categories;

                    for(int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var category = new Category(row);

                        categories.Add(category);
                    }

                    return categories;

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
    }
}
