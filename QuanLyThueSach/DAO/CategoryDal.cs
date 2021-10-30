using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class CategoryDal
    {
        private readonly string _connectionString;
        private static CategoryDal _instance;
        public static CategoryDal Instance()
        {
            if(_instance == null)
            {
                _instance = new CategoryDal();
            }
            return _instance;
        }
        public CategoryDal()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<BaseEntity> LoadCategoriesToCombobox()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getCategoriesToCombobox", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<BaseEntity> categories = new List<BaseEntity>();

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
