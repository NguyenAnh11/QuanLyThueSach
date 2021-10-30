using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.DTO;


namespace QuanLyThueSach.DAO
{
    public class BookDal
    {
        private readonly string _connectionString;
        private static BookDal _instance;
        public static BookDal Instance()
        {
            if(_instance == null)
            {
                _instance = new BookDal();
            }
            return _instance;
        }
        public BookDal()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public IList<BookDisplayDto> GetBooks()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("sp_getBooks", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    var adapter = new SqlDataAdapter(command);
                    var data = new DataTable();
                    adapter.Fill(data);
                    IList<BookDisplayDto> books = new List<BookDisplayDto>();
                    if (data.Rows.Count == 0) return books;
                    for(int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];
                        var book = new BookDisplayDto(row);
                        books.Add(book);
                    }
                    return books;
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
        public int AddBook(BookAddDto book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("sp_addBook", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name", book.Name);
                    command.Parameters.Add("@page", SqlDbType.Int).Value = book.Page;
                    command.Parameters.Add("@number", SqlDbType.Int).Value = book.Number;
                    command.Parameters.Add("@price", SqlDbType.Int).Value = book.Price;
                    command.Parameters.Add("@rent_price", SqlDbType.Int).Value = book.RentPrice;
                    command.Parameters.Add("@note", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(book.Note) ? (object)DBNull.Value : book.Note;
                    command.Parameters.Add("@image", SqlDbType.NVarChar).Value = book.Image;
                    command.Parameters.Add("@category_id", SqlDbType.Int).Value = book.CategoryId;
                    command.Parameters.Add("@author_id", SqlDbType.Int).Value = book.AuthorId;
                    command.Parameters.Add("@publisher_id", SqlDbType.Int).Value = book.PublisherId;
                    command.Parameters.Add("@language_id", SqlDbType.Int).Value = book.LanguageId;
                    command.Parameters.Add("@status_id", SqlDbType.Int).Value = book.StatusId;

                    int row = command.ExecuteNonQuery();

                    return row;

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
