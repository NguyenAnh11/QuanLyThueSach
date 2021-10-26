using System;
using System.Drawing;

namespace QuanLyThueSach.Model
{
    public class ImageEx
    {
        public string FileName { get; set; }
        public Image Image { get; set; }
        public ImageEx(string filename)
        {
            FileName = filename;
            Image = Image.FromFile(filename);
        }
    }
}
