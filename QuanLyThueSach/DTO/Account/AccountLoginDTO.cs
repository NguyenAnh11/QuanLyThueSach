using FluentValidation;

namespace QuanLyThueSach.DTO.Account
{
    public class AccountLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountLoginDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
    public class AccountLoginValidator : AbstractValidator<AccountLoginDTO>
    {
        public AccountLoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Tên đăng nhập không để rỗng")
                .Matches(@"^[a-zA-Z0-9]{5,30}")
                .WithMessage("Tên đăng nhập có độ dài 6 - 30 ký tự và không chứa ký tự đặc biệt");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Mật khẩu không để rỗng")
                .Matches(@"\d{6,30}")
                .WithMessage("Mật khẩu có độ dài 6 - 30 ký tự và chỉ chứa số");
        }
    }
}
