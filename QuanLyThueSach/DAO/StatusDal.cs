using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DAO
{
    public class StatusDal
    {
        private readonly string _connectionString;

        private static StatusDal _instance;

        public static StatusDal Instance()
        {
            if (_instance == null)
            {
                _instance = new StatusDal();
            }
            return _instance;
        }
        public StatusDal()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        public IList<BaseEntity> LoadStatusToCombobox()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getStatusToCombobox", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<BaseEntity> statuss = new List<BaseEntity>();

                    if (data.Rows.Count == 0) return statuss;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var status = new BaseEntity(row);

                        statuss.Add(status);
                    }

                    return statuss;

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
