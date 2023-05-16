using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CK
{
    public partial class detailStudent : Form
    {
        BUS_HocVien busHV = new BUS_HocVien();
        public detailStudent()
        {
            InitializeComponent();
        }

        public void detailHV(DTO_Hocvien hv)
        {
            idTB.Text = hv.Hocvien_id;
            nameTB.Text = hv.Hocvien_fullName;
            dobDT.Value = DateTime.Parse(hv.Hocvien_dob);
            genderCB.SelectedItem = hv.Hocvien_gender;
            addressTB.Text = hv.Hocvien_address;
            sdtTB.Text = hv.Hocvien_sdt;
            emailTB.Text = hv.Hocvien_email;
            dpvDT.Value = DateTime.Parse(hv.Hocvien_dpv);
            imgPTB.Image = Image.FromFile(hv.Hocvien_pathImage);
            imgPTB.Tag = hv.Hocvien_pathImage;
            statusCB.SelectedItem = hv.Hocvien_status;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        public void CopyFileWithTemp(string sourcePath, string destinationPath)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(sourcePath));

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (FileStream tempStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                sourceStream.CopyTo(tempStream);
            }

            if (File.Exists(destinationPath))
            {
                imgPTB.Image.Dispose();
                imgPTB.Image = null;
                File.Delete(destinationPath);
            }

            File.Move(tempPath, destinationPath);
        }

        public delegate void UpdateDataEventHandler(object sender, EventArgs e);
        // Sự kiện
        public event UpdateDataEventHandler UpdateData;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            object a = genderCB.SelectedItem;
            string gender = Convert.ToString(a);
            object b = statusCB.SelectedItem;
            string status = Convert.ToString(b);
            string serverImagePath = Path.Combine(@"C:\Users\Admin\source\repos\CK\images", Path.GetFileName((string)imgPTB.Tag));
            CopyFileWithTemp((string)imgPTB.Tag, serverImagePath);
            DTO_Hocvien hv = new DTO_Hocvien(idTB.Text, nameTB.Text, dobDT.Value.ToShortDateString(), gender, addressTB.Text, sdtTB.Text, emailTB.Text, dpvDT.Value.ToShortDateString(), serverImagePath, status);
            busHV.suaHocVien(hv);
            UpdateData?.Invoke(this, e);
            this.Close();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra số điện thoại hợp lệ (thích ứng theo quốc gia hoặc định dạng số điện thoại mong muốn)
            string pattern = @"^\d{10}$"; // Ví dụ này kiểm tra số điện thoại gồm 10 chữ số
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private void sdtTB_Validating(object sender, CancelEventArgs e)
        {
            string input = sdtTB.Text;

            if (!IsValidPhoneNumber(input))
            {
                // Hiển thị thông báo lỗi nếu số điện thoại không hợp lệ
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Đặt focus trở lại TextBox
                e.Cancel = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            // Biểu thức chính quy kiểm tra email hợp lệ
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }

        private void emailTB_Validating(object sender, CancelEventArgs e)
        {
            string input = emailTB.Text;

            if (!IsValidEmail(input))
            {
                // Hiển thị thông báo lỗi nếu email không hợp lệ
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Đặt focus trở lại TextBox
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imgPTB.Image?.Dispose();
            imgPTB.Image = null;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị hình ảnh được chọn trong PictureBox
                imgPTB.Image = new Bitmap(openFileDialog.FileName);
                imgPTB.Tag = openFileDialog.FileName;
            }
        }
    }
}
