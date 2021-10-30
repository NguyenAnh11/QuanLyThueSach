namespace QuanLyThueSach.DTO
{
    public class BookUpdateDto : BookAddDto
    {
        public int Id { get; set; }
        public BookUpdateDto(int id, string name, int page, int number, int price, int rentPrice, string note, string image, int categoryId, int authorId, int publisherId, int languageId, int statusId) 
            :base(name, page, number, price, rentPrice, note, image, categoryId, authorId, publisherId, languageId, statusId)
        {
            Id = id;
        }
    }
}
