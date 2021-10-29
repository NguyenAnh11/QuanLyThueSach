using System.Data;

namespace QuanLyThueSach.Model
{
    public class LanguageBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LanguageBook(int id, string name) 
        {
            Id = id;
            Name = name;
        }
        public LanguageBook(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
