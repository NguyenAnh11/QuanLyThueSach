using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class PublisherDAO
    {
        private readonly string _connectionString;
        private static PublisherDAO _instance;
        public static PublisherDAO Instance()
        {
            if (_instance == null)
            {
                _instance = new PublisherDAO();
            }
            return _instance;
        }
        public PublisherDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<Publisher> GetPublishers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getPublishers", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<Publisher> publishers = new List<Publisher>();

                    if (data.Rows.Count == 0) return publishers;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var publisher = new Publisher(row);

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
