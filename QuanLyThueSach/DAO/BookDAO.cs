using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using QuanLyThueSach.Model;


namespace QuanLyThueSach.DAO
{
    public class BookDAO
    {
        private readonly string _connectionString;

        private static BookDAO _instance;

        public static BookDAO Instance()
        {
            if(_instance == null)
            {
                _instance = new BookDAO();
            }
            return _instance;
        }
        public BookDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public IList<Book> GetBooks()
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

                    IList<Book> books = new List<Book>();
                    if (data.Rows.Count == 0) return books;

                    for(int index = 0; index < data.Rows.Count; index++)
                    {
                        var row = data.Rows[index];

                        var book = new Book(row);

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
        public int AddBook(Book book)
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
                    command.Parameters.Add("@language_id", SqlDbType.Int).Value = book.LanguageBookId;
                    command.Parameters.Add("@statusbook_id", SqlDbType.Int).Value = book.StatusBookId;

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
