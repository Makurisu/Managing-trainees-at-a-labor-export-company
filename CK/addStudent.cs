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
using System.Text.RegularExpressions;

namespace CK
{
    public partial class addStudent : Form
    {
        BUS_HocVien busHV = new BUS_HocVien();
        public addStudent()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (imgPTB.Tag == "" || nameTB.Text == "" || addressTB.Text == "" || sdtTB.Text == "" || emailTB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }   
            else
            {
                object a = genderCB.SelectedItem;
                string b = Convert.ToString(a);
                string serverImagePath = Path.Combine(@"C:\Users\Admin\source\repos\CK\images", Path.GetFileName((string)imgPTB.Tag));
                CopyFileWithTemp((string)imgPTB.Tag, serverImagePath);
                DTO_Hocvien hv  = new DTO_Hocvien("", nameTB.Text, dobDT.Value.ToShortDateString(), b, addressTB.Text, sdtTB.Text, emailTB.Text, dpvDT.Value.ToShortDateString(), serverImagePath, "");
                if (busHV.themHocVien(hv))
                {
                    this.Alert("Success Alert", Form_Alert.enmType.Success);
                }
                //this.Alert("Success Alert", Form_Alert.enmType.Success);
            }
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

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
    }
}
