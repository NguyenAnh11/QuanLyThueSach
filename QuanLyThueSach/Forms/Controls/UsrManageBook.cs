using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuanLyThueSach.DAO;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.Forms.Controls
{
    public partial class UsrManageBook : UserControl
    {
        private OpenFileDialog _openFileDialog;

        private ImageEx _imageEx;

        public UsrManageBook()
        {
            InitializeComponent();

            _openFileDialog = new OpenFileDialog();

            _openFileDialog.Filter = "Image Files(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";

            _openFileDialog.Multiselect = false;
        }

        private void UsrManageBook_Load(object sender, EventArgs e)
        {

            btnAdd.Enabled = true;
            btnSelect.Enabled = true;
            btnCancel.Enabled = true;
            btnTakePhoto.Enabled = true;

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnDeletePhoto.Enabled = false;

            txtBookId.Enabled = false;


            gridBooks.ClearSelection();

            gridBooks.CurrentCell = null;

            gridBooks.DataSource = BookDAO.Instance().GetBooks();

            var categories = CategoryDAO.Instance().GetCategories();
            cbBookCategory.Items.AddRange(categories.ToArray());

            var authors = AuthorDAO.Instance().GetAuthors();
            cbBookAuthor.Items.AddRange(authors.ToArray());

            var publisher = PublisherDAO.Instance().GetPublishers();
            cbBookPublisher.Items.AddRange(publisher.ToArray());

            var languages = LanguageDAO.Instance().GetLanguageBooks();
            cbBookLanguage.Items.AddRange(languages.ToArray());

            var status = StatusBookDAO.Instance().GetStatusBooks();
            cbBookStatus.Items.AddRange(status.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Folder.DefaultAvatarBook;

                if (_imageEx != null)
                {
                    path = _imageEx.FileName;
                }

                var book = GetData();

                string error = ValidateData(book);

                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                BookDAO.Instance().AddBook(book);

                File.Copy(path, book.Image);

                MessageBox.Show("Thêm sách thành công");

                gridBooks.DataSource = BookDAO.Instance().GetBooks();

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            DialogResult dialog = _openFileDialog.ShowDialog();

            if(dialog == DialogResult.OK)
            {
                string name =  _openFileDialog.FileName;

                _imageEx = new ImageEx(name);

                pictureBook.Image = _imageEx.Image;

                btnDeletePhoto.Enabled = true;
            }
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            btnDeletePhoto.Enabled = false;

            _imageEx = new ImageEx(Folder.DefaultAvatarBook);

            pictureBook.Image = _imageEx.Image;
        }

        private string ValidateData(Book book)
        {

            if (string.IsNullOrEmpty(book.Name))
            {
                return "Tên không để rỗng";
            }
            else if (book.Number < 0)
            {
                return "Số lượng phải lớn hơn hoặc bằng 0";
            }
            else if (book.Price <= 0)
            {
                return "Giá phải lớn hơn 0";
            }
            else if (book.RentPrice <= 0)
            {
                return "Giá bán phải lớn hơn 0";
            }
            else if (book.Page < 0)
            {
                return "Số trang lớn hơn 0";
            }
            else if (book.CategoryId == -1)
            {
                return "Chọn loại sách cho sách";
            }
            else if (book.AuthorId == -1)
            {
                return "Chọn tác giả cho sách";
            }
            else if (book.PublisherId == -1)
            {
                return "Chọn nhà xuất bản cho sách";
            }
            else if (book.LanguageBookId == -1)
            {
                return "Chọn ngôn ngữ cho sách";
            }
            else if (book.StatusBookId == -1)
            {
                return "Chọn trạng thái cho sách";
            }
            return null;
        }

        private Book GetData()
        {

            string name = txtName.Text.Trim();

            int page, number, price, rentPrice;

            if (!int.TryParse(txtPage.Text.Trim(), out page))
            {
                throw new Exception("Số trang nhập phải dạng số nguyên");
            }
            if (!int.TryParse(txtNumber.Text.Trim(), out number))
            {
                throw new Exception("Số lượng nhập phải dạng số nguyên");
            }
            if (!int.TryParse(txtPrice.Text.Trim(), out price))
            {
                throw new Exception("Giá nhập phải dạng số nguyên");
            }
            if (!int.TryParse(txtRentPrice.Text.Trim(), out rentPrice))
            {
                throw new Exception("Giá bán nhập phải dạng số nguyên");
            }

            string note = txtNote.Text.Trim();

            string path = Folder.DefaultAvatarBook;

            if (_imageEx != null)
            {
                path = _imageEx.FileName;
            }

            string format = Path.GetExtension(path);

            string newPath = Path.Combine(Folder.Images, Guid.NewGuid().ToString() + format);

            int categoryId = ((Category)cbBookCategory.SelectedItem).Id;

            int authorId = ((Author)cbBookAuthor.SelectedItem).Id;

            int publisherId = ((Publisher)cbBookAuthor.SelectedItem).Id;

            int languageId = ((LanguageBook)cbBookLanguage.SelectedItem).Id;

            int statusId = ((StatusBook)cbBookStatus.SelectedItem).Id;

            var bookDto = new Book(name, page, number, price, rentPrice, note, newPath, categoryId, authorId, publisherId, languageId, statusId);

            return bookDto;

        }

    }
}
