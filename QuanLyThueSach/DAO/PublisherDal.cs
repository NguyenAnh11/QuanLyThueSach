using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class PublisherDal
    {
        private readonly string _connectionString;

        private static PublisherDal _instance;

        public static PublisherDal Instance()
        {
            if (_instance == null)
            {
                _instance = new PublisherDal();
            }
            return _instance;
        }
        public PublisherDal()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<BaseEntity> LoadPublishersToCombobox()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getPublishersToCombobox", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<BaseEntity> publishers = new List<BaseEntity>();

                    if (data.Rows.Count == 0) return publishers;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var publisher = new BaseEntity(row);

                        publishers.Add(publisher);
                    }

                    return publishers;

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
