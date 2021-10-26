using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyThueSach.Model;
using QuanLyThueSach.DTO;

namespace QuanLyThueSach.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO _instance { get; set; }
        private string _connectionString { get; set; }
        public static EmployeeDAO Instance()
        {
            if(_instance == null)
            {
                _instance = new EmployeeDAO();
            }
            return _instance;
        }
        public EmployeeDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        
        public IList<ShiftInDay> GetDayHaveShiftInMonthAndInYear(int month, int year, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getDayHaveShiftInMonthAndInYear", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@employee_id", id);
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@year", year);

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<ShiftInDay> shiftInDays = new List<ShiftInDay>();

                    if (data.Rows.Count == 0) return shiftInDays;


                    for(int i = 0; i < data.Rows.Count; i++)
                    {
                        var shiftInDay = new ShiftInDay(data.Rows[i]);
                        shiftInDays.Add(shiftInDay);
                    }

                    connection.Close();

                    return shiftInDays;
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

        public IList<ShiftDto> GetShiftInDay(int employeeId, DateTime date)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getShiftInDay", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@employee_id", employeeId);
                    command.Parameters.AddWithValue("@day", date);

                    var adapter = new SqlDataAdapter(command);

                    var data = new DataTable();

                    adapter.Fill(data);

                    IList<ShiftDto> shiftDtos = new List<ShiftDto>();

                    if (data.Rows.Count == 0) return shiftDtos;

                    for(int index = 0; index < data.Rows.Count; index++)
                    {

                        var shiftDto = new ShiftDto(data.Rows[index]);

                        shiftDtos.Add(shiftDto);
                    }

                    connection.Close();

                    return shiftDtos;

                }catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void UpdateShiftSelectInDay(int employeeId, int shiftId, DateTime date)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_updateShiftSelecteInDay", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@employee_id", employeeId);
                    command.Parameters.AddWithValue("@shift_id", shiftId);
                    command.Parameters.AddWithValue("@day", date);

                    command.ExecuteNonQuery();

                    connection.Close();
                    
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
