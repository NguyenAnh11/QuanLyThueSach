using System;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyThueSach.Model;

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
        
        //get all day have shift in month and in year
        public IList<ShiftInDay> GetDayHaveShiftInMonthAndInYear(int month, int year, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_GetDayHaveShiftInMonthAndInYear", connection);
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

        //get all shift in day
        public IList<Shift> GetAllShiftHaveInDay(int employeeId, DateTime date)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getAllShiftInDay", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@employee_id", employeeId);
                    command.Parameters.AddWithValue("@day", date);

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<Shift> shifts = new List<Shift>();

                    if (data.Rows.Count == 0) return shifts;

                    for(int index = 0; index < data.Rows.Count; index++)
                    {
                        var shift = new Shift(data.Rows[index]);
                        shifts.Add(shift);
                    }

                    connection.Close();

                    return shifts;

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

        public IList<Shift> GetAllShift()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_getAllShift", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    var data = new DataTable();

                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    IList<Shift> shifts = new List<Shift>();

                    if (data.Rows.Count == 0) return shifts;

                    for (int index = 0; index < data.Rows.Count; index++)
                    {
                        var shift = new Shift(data.Rows[index]);
                        shifts.Add(shift);
                    }

                    connection.Close();

                    return shifts;

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
