using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using BUS;
using DTO;

namespace CK
{
    public partial class infoStudent : Form
    {
        BUS_HocVien busHocVien = new BUS_HocVien();
        BUS_studentContract busStudentContract = new BUS_studentContract();
        DTO_Hocvien dtoHocVien = new DTO_Hocvien();
        public infoStudent()
        {
            InitializeComponent();
        }

        private void infoStudent_Load(object sender, EventArgs e)
        {
            DataTable student = busHocVien.getHocVien(DTO_Account.tempUsername);
            idTB.Text = student.Rows[0][0].ToString();
            nameTB.Text = student.Rows[0][1].ToString();
            dobDT.Value = DateTime.Parse(student.Rows[0][2].ToString());
            genderCB.SelectedItem = student.Rows[0][3].ToString();
            addressTB.Text = student.Rows[0][4].ToString();
            sdtTB.Text = student.Rows[0][5].ToString();
            emailTB.Text = student.Rows[0][6].ToString();
            dpvDT.Value = DateTime.Parse(student.Rows[0][7].ToString());
            imgPTB.Image = Image.FromFile(student.Rows[0][8].ToString());
            imgPTB.Tag = busHocVien.getHocVien(DTO_Account.tempUsername).Rows[0][8].ToString();
            statusCB.SelectedItem = student.Rows[0][9].ToString();
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
                File.Delete(destinationPath);
            }

            File.Move(tempPath, destinationPath);
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            object a = genderCB.SelectedItem;
            string gender = Convert.ToString(a);
            object b = statusCB.SelectedItem;
            string status = Convert.ToString(b);
            string serverImagePath = Path.Combine(@"C:\Users\Admin\source\repos\CK\images", Path.GetFileName((string)imgPTB.Tag));
            CopyFileWithTemp((string)imgPTB.Tag, serverImagePath);
            DTO_Hocvien hv = new DTO_Hocvien(idTB.Text, nameTB.Text, dobDT.Value.ToShortDateString(), gender, addressTB.Text, sdtTB.Text, emailTB.Text, dpvDT.Value.ToShortDateString(), serverImagePath, status);
            if(busHocVien.suaHocVien(hv))
            {
                this.Alert("Success Alert", Form_Alert.enmType.Success);
            }    
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new changePassword().ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (busStudentContract.checkStudentContract(DTO_Account.tempUsername))
            {
                new viewContractRegisted().ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn chưa kí hợp đồng nào!");
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
