using System.Data;
using System.ComponentModel;
namespace QuanLyThueSach.Model
{
    public class Book 
    {
        [DisplayName("Mã sách")]
        public int Id { get; set; }

        [DisplayName("Tên sách")]
        public string Name { get; set; }

        [DisplayName("Số trang")]
        public int Page { get; set; }

        [DisplayName("Số lượng")]
        public int Number { get; set; }

        [DisplayName("Giá")]
        public int Price { get; set; }

        [DisplayName("Giá bán")]
        public int RentPrice { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }

        [DisplayName("Ảnh")]
        [Browsable(false)]
        public string Image { get; set; }

        [Browsable(false)]
        public int CategoryId { get; set; }

        [Browsable(false)]
        public int AuthorId { get; set; }

        [Browsable(false)]
        public int PublisherId { get; set; }

        [Browsable(false)]
        public int LanguageBookId { get; set; }

        [Browsable(false)]
        public int StatusBookId { get; set; }

        public Book(
            int id, string name, int page, int number, int price, int rentPrice, string note, string image,
            int categoryId, int authorId, int publisherId, int languageId, int statusId) 
        {
            Id = id;
            Name = name;
            Page = page;
            Price = price;
            Number = number;
            Note = note;
            Image = image;
            RentPrice = rentPrice;
            CategoryId = categoryId;
            AuthorId = authorId;
            PublisherId = publisherId;
            LanguageBookId = languageId;
            StatusBookId = statusId;
        }
        public Book(
            string name, int page, int number, int price, int rentPrice, string note, string image,
            int categoryId, int authorId, int publisherId, int languageId, int statusId)
        {
            Name = name;
            Page = page;
            Price = price;
            Number = number;
            Note = note;
            Image = image;
            RentPrice = rentPrice;
            CategoryId = categoryId;
            AuthorId = authorId;
            PublisherId = publisherId;
            LanguageBookId = languageId;
            StatusBookId = statusId;
        }
        public Book(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Page = (int)row["number_page"];
            Price = (int)row["price"];
            Number = (int)row["number_book"];
            Image = row["image"].ToString();
            RentPrice = (int)row["rent_price"];
            Note = row.IsNull("note") ? string.Empty : row["note"].ToString();
            CategoryId = (int)row["category_id"];
            AuthorId = (int)row["author_id"];
            PublisherId = (int)row["publisher_id"];
            LanguageBookId = (int)row["language_id"];
            StatusBookId = (int)row["status_id"];
        }

    }
}
