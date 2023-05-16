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
    public partial class addClass : Form
    {
        BUS_Class busClass = new BUS_Class();
        BUS_Language busLanguage = new BUS_Language();
        BUS_GiangVien busGiangVien = new BUS_GiangVien();
        public addClass()
        {
            InitializeComponent();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void addBT_Click(object sender, EventArgs e)
        {
            if(nameTB.Text == "" || feeTB.Text == "" || teacherCB.GetItemText(teacherCB.SelectedValue) == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }    
            else
            {
                string selectedItemLanguage = languageCB.GetItemText(languageCB.SelectedItem);
                string selectedItemTeacher = teacherCB.GetItemText(teacherCB.SelectedValue);
                DTO_Class dtoClass = new DTO_Class("", selectedItemTeacher, nameTB.Text, selectedItemLanguage, int.Parse(feeTB.Text));
                if (busClass.themClass(dtoClass))
                {
                    this.Alert("Success Alert", Form_Alert.enmType.Success);
                    mainDGV.DataSource = busClass.getClass();
                }
            }
        }

        private void addClass_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = busClass.getClass();
            languageCB.DataSource = busLanguage.getLanguage();
            languageCB.DisplayMember = "name_language";
            languageCB.ValueMember = "name_language";
            languageCB.SelectedIndex = 0;
        }

        private void languageCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = languageCB.GetItemText(languageCB.SelectedItem);
            List<DTO_GiangVien> giangvienList = busGiangVien.getGiangVienIdName(selectedItem);
            teacherCB.DataSource = giangvienList;
            teacherCB.DisplayMember = "GiangVien_idName";
            teacherCB.ValueMember = "GiangVien_id";
        }

        private bool IsValidFee(string fee)
        {
            // Biểu thức chính quy kiểm tra số điện thoại hợp lệ (thích ứng theo quốc gia hoặc định dạng số điện thoại mong muốn)
            string pattern = @"^\d{1,15}$";
            return Regex.IsMatch(fee, pattern);
        }

        private void feeTB_Validating(object sender, CancelEventArgs e)
        {
            string input = feeTB.Text;

            if (!IsValidFee(input))
            {
                // Hiển thị thông báo lỗi nếu số điện thoại không hợp lệ
                MessageBox.Show("Học phí không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Đặt focus trở lại TextBox
                e.Cancel = true;
            }
        }

        private void mainDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int number;
                if (!int.TryParse(e.FormattedValue.ToString(), out number))
                {
                    e.Cancel = true;
                    MessageBox.Show("Vui lòng chỉ nhập số nguyên.");
                }
            }
        }

        private void searchBT_Click(object sender, EventArgs e)
        {
            object a = searchCB.SelectedItem;
            string b = Convert.ToString(a);
            String type;
            if (b == "Tên khoa học")
            {
                type = "course_name";
            }
            else
            {
                type = "id";
            }
            mainDGV.DataSource = busClass.searchClass(type, searchTB.Text);
        }

        private void deleteBT_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainDGV.SelectedRows[0];
            DTO_Class dtoClass = new DTO_Class(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(),0);
            if (busClass.xoaClass(dtoClass))
            {
                this.Alert("Success Alert", Form_Alert.enmType.Success);
                mainDGV.DataSource = busClass.getClass();
            }
            else
            {
                MessageBox.Show("Không thể xóa lớp đang học học viên học");
            }
        }
    }
}
