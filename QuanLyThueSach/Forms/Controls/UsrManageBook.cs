using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThueSach.DAO;
using QuanLyThueSach.DTO;
using QuanLyThueSach.Model;
using System.Collections.Generic;

namespace QuanLyThueSach.Forms.Controls
{
    public partial class UsrManageBook : UserControl
    {
        private OpenFileDialog _openFileDialog;
        private ImageEx _imageEx;
        private bool _hasLoadCategory;
        private bool _hasLoadAuthor;
        private bool _hasLoadPublisher;
        private bool _hasLoadLanguage;
        private bool _hasLoadStatus;

        public UsrManageBook()
        {
            InitializeComponent();

            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Image Files(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
            _openFileDialog.Multiselect = false;

            _hasLoadCategory = false;
            _hasLoadAuthor = false;
            _hasLoadPublisher = false;
            _hasLoadLanguage = false;
            _hasLoadStatus = false;
        }

        private void UsrManageBook_Load(object sender, EventArgs e)
        {

            btnAdd.Enabled = true;
            btnSelect.Enabled = true;
            btnCancel.Enabled = true;
            btnTakePhoto.Enabled = true;

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            InitializeDataGridView();

            var books = BookDal.Instance().GetBooks();

            AddDataToDataGridView(books);

            gridBooks.ClearSelection();
        }

        private void InitializeDataGridView()
        {
            //visible
            gridBooks.Columns.Add("Id", "Mã sách");
            gridBooks.Columns.Add("Name", "Tên sách");
            gridBooks.Columns.Add("Page", "Số trang");
            gridBooks.Columns.Add("Number", "Số lượng");
            gridBooks.Columns.Add("Price", "Giá");
            gridBooks.Columns.Add("RentPrice", "Giá bán");
            gridBooks.Columns.Add("Note", "Ghi chú");
            gridBooks.Columns.Add("CategoryName", "Loại hàng");
            gridBooks.Columns.Add("AuthorName", "Tác giả");
            gridBooks.Columns.Add("PublisherName", "Nhà xuất bản");
            gridBooks.Columns.Add("LanguageName", "Ngôn ngữ");
            gridBooks.Columns.Add("StatusName", "Tình trạng");
            //unvisible
            gridBooks.Columns.Add("Image", "Ảnh");
            gridBooks.Columns[12].Visible = false;

            gridBooks.Columns.Add("CategoryId", "Mã loại hàng");
            gridBooks.Columns[13].Visible = false;

            gridBooks.Columns.Add("AuthorId", "Mã tác giả");
            gridBooks.Columns[14].Visible = false;

            gridBooks.Columns.Add("PublisherId", "Mã nhà xuất bản");
            gridBooks.Columns[15].Visible = false;

            gridBooks.Columns.Add("LanguageId", "Mã ngôn ngữ");
            gridBooks.Columns[16].Visible = false;

            gridBooks.Columns.Add("StatusId", "Mã tình trạng");
            gridBooks.Columns[17].Visible = false;

            gridBooks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            for (int index = 0; index < gridBooks.Columns.Count; index++)
            {
                gridBooks.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void AddDataToDataGridView(IList<BookDisplayDto> books)
        {
            gridBooks.Rows.Clear();
            foreach(var book in books)
            {
                var row = new DataGridViewRow();
                row.CreateCells(gridBooks);
                row.Cells[0].Value = book.Id;
                row.Cells[1].Value = book.Name;
                row.Cells[2].Value = book.Page;
                row.Cells[3].Value = book.Number;
                row.Cells[4].Value = book.Price;
                row.Cells[5].Value = book.RentPrice;
                row.Cells[6].Value = book.Note;
                row.Cells[7].Value = book.CategoryName;
                row.Cells[8].Value = book.AuthorName;
                row.Cells[9].Value = book.PublisherName;
                row.Cells[10].Value = book.LanguageName;
                row.Cells[11].Value = book.StatusName;
                row.Cells[12].Value = book.Image;
                row.Cells[13].Value = book.CategoryId;
                row.Cells[14].Value = book.AuthorId;
                row.Cells[15].Value = book.PublisherId;
                row.Cells[16].Value = book.LanguageId;
                row.Cells[17].Value = book.StatusId;
                gridBooks.Rows.Add(row);
            }
        }

        private int GetValueFromCombobox(ComboBox combobox)
        {
            if (combobox.SelectedIndex == -1) return -1;
            if (combobox.Items.Count == 0) return -1;
            var data = (Category)combobox.SelectedItem;
            return data.Id;
        }

        private void SetValueToCombobox(ComboBox comboBox, IList<BaseEntity> baseEntities)
        {
            if(baseEntities.Count > 0)
            {
                foreach(var baseEntity in baseEntities)
                {
                    comboBox.Items.Add(baseEntity);
                }
            }
        }

        private void SetSelectIndexCombobox(ComboBox combobox, int value)
        {
            for(int index = 0; index < combobox.Items.Count; index++)
            {
                var item = (BaseEntity)combobox.Items[index];
                if(item.Id == value)
                {
                    combobox.SelectedIndex = index;
                }
            }
        }

        private void Clear()
        {
            txtBookId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtPage.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtRentPrice.Text = string.Empty;

            cbBookCategory.SelectedIndex = -1;
            cbBookAuthor.SelectedIndex = -1;
            cbBookPublisher.SelectedIndex = -1;
            cbBookLanguage.SelectedIndex = -1;
            cbBookStatus.SelectedIndex = -1;

            _imageEx = null;

            pictureBook.Image = null;
        }

        private void Insert(BookUpdateDto book)
        {
            txtBookId.Text = book.Id.ToString();
            txtName.Text = book.Name;
            txtPage.Text = book.Page.ToString();
            txtNumber.Text = book.Number.ToString();
            txtPrice.Text = book.Price.ToString();
            txtRentPrice.Text = book.RentPrice.ToString();
            txtNote.Text = book.Note;

            _imageEx = new ImageEx(book.Image);

            pictureBook.Image = _imageEx.Image;

            SetSelectIndexCombobox(cbBookCategory, book.CategoryId);
            SetSelectIndexCombobox(cbBookAuthor, book.AuthorId);
            SetSelectIndexCombobox(cbBookPublisher, book.PublisherId);
            SetSelectIndexCombobox(cbBookLanguage, book.LanguageId);
            SetSelectIndexCombobox(cbBookStatus, book.StatusId);
        }

        private BookUpdateDto GetRowValue(DataGridViewRow row)
        {
            int id = int.Parse(row.Cells[0].Value.ToString());
            string name = row.Cells[1].Value.ToString();
            int page = int.Parse(row.Cells[2].Value.ToString());
            int number = int.Parse(row.Cells[3].Value.ToString());
            int price = int.Parse(row.Cells[4].Value.ToString());
            int rentPrice = int.Parse(row.Cells[5].Value.ToString());
            string note = row.Cells[6].Value.ToString();
            string path = row.Cells[12].Value.ToString();
            int categoryId = int.Parse(row.Cells[13].Value.ToString());
            int authorId = int.Parse(row.Cells[14].Value.ToString());
            int publisherId = int.Parse(row.Cells[15].Value.ToString());
            int languageId = int.Parse(row.Cells[16].Value.ToString());
            int statusId = int.Parse(row.Cells[17].Value.ToString());

            return new BookUpdateDto(id, name, page, number, price, rentPrice, note, path, 
                categoryId, authorId, publisherId, languageId, statusId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string note = txtNote.Text.Trim();

                int page = 0, number = 0, price = 0, rentPrice = 0;

                if(!int.TryParse(txtPage.Text.Trim(), out page))
                {
                    throw new Exception("Số trang nhập phải dạng nguyên");
                } else if(!int.TryParse(txtNumber.Text.Trim(), out number))
                {
                    throw new Exception("Số lượng nhập phải dạng nguyên");
                } else if(!int.TryParse(txtPrice.Text.Trim(), out price))
                {
                    throw new Exception("Giá nhập phải dạng nguyên");
                } else if(!int.TryParse(txtRentPrice.Text.Trim(), out rentPrice))
                {
                    throw new Exception("Giá bán phải dạng nguyên");
                }

                string path = Folder.DefaultAvatarBook;
                if (_imageEx != null) path = _imageEx.FileName;

                string format = Path.GetExtension(path);
                string newPath = Path.Combine(Folder.Images, Guid.NewGuid().ToString() + format);

                int categoryId = GetValueFromCombobox(cbBookCategory);

                int authorId = GetValueFromCombobox(cbBookAuthor);

                int publisherId = GetValueFromCombobox(cbBookPublisher);

                int languageId = GetValueFromCombobox(cbBookLanguage);

                int statusId = GetValueFromCombobox(cbBookStatus);

                var bookAddDto = new BookAddDto(name, page, number, price, rentPrice, note, newPath, categoryId, 
                        authorId, publisherId, languageId, statusId);

                var validator = new BookAddDtoValidator();

                var result = validator.Validate(bookAddDto);

                if(!result.IsValid)
                {
                    var errorMesage = new StringBuilder();

                    foreach(var error in result.Errors)
                    {
                        errorMesage.AppendLine(error.ErrorMessage);
                    }

                    throw new Exception(errorMesage.ToString());
                } else
                {
                    BookDal.Instance().AddBook(bookAddDto);

                    File.Copy(path, newPath);

                    Clear();

                    MessageBox.Show("Thêm sách thành công");
                }
                
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
            }
        }

        private void cbBookCategory_Click(object sender, EventArgs e)
        {
            if (!_hasLoadCategory)
            {
                var categories = CategoryDal.Instance().LoadCategoriesToCombobox();

                SetValueToCombobox(cbBookCategory, categories);

                _hasLoadCategory = true;
            }
        }

        private void cbBookAuthor_Click(object sender, EventArgs e)
        {
            if (!_hasLoadAuthor)
            {
                var authors = AuthorDal.Instance().LoadAuthorsToCombobox();

                SetValueToCombobox(cbBookAuthor, authors);

                _hasLoadAuthor = true;
            }
        }

        private void cbBookPublisher_Click(object sender, EventArgs e)
        {
            if (!_hasLoadPublisher)
            {
                var publishers = PublisherDal.Instance().LoadPublishersToCombobox();

                SetValueToCombobox(cbBookPublisher, publishers);

                _hasLoadPublisher = true;
            }
        }

        private void cbBookStatus_Click(object sender, EventArgs e)
        {
            if (!_hasLoadStatus)
            {
                var status = StatusDal.Instance().LoadStatusToCombobox();

                SetValueToCombobox(cbBookStatus, status);

                _hasLoadStatus = true;
            }
        }

        private void cbBookLanguage_Click(object sender, EventArgs e)
        {
            if (!_hasLoadLanguage)
            {
                var languages = LanguageDal.Instance().LoadLanguagesToCombobox();

                SetValueToCombobox(cbBookLanguage, languages);

                _hasLoadLanguage = true;
            }
        }

        private void gridBooks_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            var row = gridBooks.SelectedRows[0];

            var value = GetRowValue(row);

            //insert data to form
            Insert(value);
        }
    }
}
