using System;
using FluentValidation;

namespace QuanLyThueSach.DTO
{
    public class BookAddDto
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int RentPrice { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int LanguageId { get; set; }
        public int StatusId { get; set; }
        public BookAddDto(string name, int page, int number, int price, int rentPrice, string note, string image, int categoryId, int authorId, int publisherId, int languageId, int statusId)
        {
            Name = name;
            Page = page;
            Number = number;
            Price = price;
            RentPrice = rentPrice;
            Note = note;
            Image = image;
            CategoryId = categoryId;
            AuthorId = authorId;
            PublisherId = publisherId;
            LanguageId = languageId;
            StatusId = statusId;
        }
    }

    public class BookAddDtoValidator : AbstractValidator<BookAddDto>
    {
        public BookAddDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Tên không để rỗng");
            RuleFor(x => x.Number)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Số lượng lớn hơn hoặc bằng 0");
            RuleFor(x => x)
                .Must(x => x.Page > 0 && x.Price > 0 && x.RentPrice > 0)
                .WithMessage("Số trang, giá, giá bán có giá trị lớn hơn 0");
            RuleFor(x => x)
                .Must(x => x.CategoryId != -1 && x.AuthorId != -1 && x.PublisherId != -1 && x.LanguageId != -1 && x.StatusId != -1)
                .WithMessage("Chọn đủ thông tin cho các thuộc tính loại hàng, tác giả, nhà xuất bản..");
        }
    }
}
