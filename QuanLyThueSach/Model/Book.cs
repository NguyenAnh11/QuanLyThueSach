using System.Data;

namespace QuanLyThueSach.Model
{
    public class Book : BaseEntity
    {
        public int Page { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int RentPrice { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
        public Book(int id, string name, int page, int number, int price, int rentPrice, string note, string image) 
            : base(id, name)
        {
            Page = page;
            Price = price;
            Number = number;
            Note = note;
            Image = image;
            RentPrice = rentPrice;
        }
        public Book(DataRow row) : base(row)
        {
            Page = row.Field<int>("number_page");
            Number = row.Field<int>("number_book");
            Price = row.Field<int>("price");
            RentPrice = row.Field<int>("rent_price");
            Image = row.Field<string>("image");
            Note = row.Field<string>("note") ?? string.Empty;
        }
    }
 
}
