using System.Data;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DTO
{
    public class BookDisplayDto : Book
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public BookDisplayDto(DataRow row) : base(row)
        {
            CategoryId = row.Field<int>("category_id");
            CategoryName = row.Field<string>("category_name");
            AuthorId= row.Field<int>("author_id");
            AuthorName = row.Field<string>("author_name");
            PublisherId = row.Field<int>("publisher_id");
            PublisherName = row.Field<string>("publisher_name");
            LanguageId = row.Field<int>("language_id");
            LanguageName = row.Field<string>("language_name");
            StatusId = row.Field<int>("status_id");
            StatusName = row.Field<string>("status_name");
        }
    }
}
