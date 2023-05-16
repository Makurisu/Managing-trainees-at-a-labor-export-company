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
    public partial class addContract : Form
    {
        BUS_Contract contract = new BUS_Contract();
        BUS_Language language = new BUS_Language();
        public addContract()
        {
            InitializeComponent();
        }

        private void addContract_Load(object sender, EventArgs e)
        {
            countryCB.DataSource = language.getLanguage();
            countryCB.DisplayMember = "name_language";
            countryCB.ValueMember = "name_language";
            countryCB.SelectedIndex = 0;
            mainDGV.DataSource = contract.getContract();
            mainDGV.Columns["id"].ReadOnly = true;
            mainDGV.Columns["status"].ReadOnly = true;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(nameTB.Text == "" || countryCB.GetItemText(countryCB.SelectedItem) == "" || nhomnganhTB.Text == "" || salaryTB.Text == "" || slotTB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                string selectedItem = countryCB.GetItemText(countryCB.SelectedItem);
                DTO_Contract dto_Contract = new DTO_Contract("", nameTB.Text, selectedItem, nhomnganhTB.Text, nghenghiepTB.Text, int.Parse(salaryTB.Text), int.Parse(slotTB.Text), "");
                if (contract.themContract(dto_Contract))
                {
                    this.Alert("Success Alert", Form_Alert.enmType.Success);
                    mainDGV.DataSource = contract.getContract();
                }    
                else
                    this.Alert("Error Alert", Form_Alert.enmType.Error);
            }    
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (mainDGV.SelectedRows.Count > 0)
            {
                DataGridViewRow row = mainDGV.SelectedRows[0];
                DTO_Contract dto_Contract = new DTO_Contract(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), int.Parse(row.Cells[5].Value.ToString()), int.Parse(row.Cells[6].Value.ToString()), "");
                if (contract.suaContract(dto_Contract))
                {
                    this.Alert("Success Alert", Form_Alert.enmType.Success);
                    mainDGV.DataSource = contract.getContract();
                }
                else
                    this.Alert("Error Alert", Form_Alert.enmType.Error);
            }
        }

        private void mainDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                int number;
                if (!int.TryParse(e.FormattedValue.ToString(), out number))
                {
                    e.Cancel = true;
                    MessageBox.Show("Vui lòng chỉ nhập số nguyên.");
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (mainDGV.SelectedRows.Count > 0)
            {
                DataGridViewRow row = mainDGV.SelectedRows[0];
                DTO_Contract dto_Contract = new DTO_Contract(row.Cells[0].Value.ToString(), "", "", "", "", 0, 0, row.Cells[5].Value.ToString());
                if (contract.xoaContract(dto_Contract))
                {
                    this.Alert("Success Alert", Form_Alert.enmType.Success);
                    mainDGV.DataSource = contract.getContract();
                }
                else
                {
                    MessageBox.Show("Không thể xóa hợp đồng đã có học viên đăng kí!");
                    this.Alert("Error Alert", Form_Alert.enmType.Error);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            object a = searchCB.SelectedItem;
            string b = Convert.ToString(a);
            String type;
            if (b == "Tên công ty")
            {
                type = "name_contracts";
            }
            else if (b == "Mã hợp đồng")
            {
                type = "id";
            }
            else
            {
                type = "country";
            }    
            mainDGV.DataSource = contract.searchContract(type, searchTB.Text);
        }

        private bool IsValidNumber(string number)
        {
            // Biểu thức chính quy kiểm tra số điện thoại hợp lệ (thích ứng theo quốc gia hoặc định dạng số điện thoại mong muốn)
            string pattern = @"^\d{1,15}$";
            return Regex.IsMatch(number, pattern);
        }

        private void slotTB_Validating(object sender, CancelEventArgs e)
        {
            string input = slotTB.Text;

            if (!IsValidNumber(input))
            {
                // Hiển thị thông báo lỗi nếu số điện thoại không hợp lệ
                MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Đặt focus trở lại TextBox
                e.Cancel = true;
            }
        }

        private void salaryTB_Validating(object sender, CancelEventArgs e)
        {
            string input = salaryTB.Text;

            if (!IsValidNumber(input))
            {
                // Hiển thị thông báo lỗi nếu số điện thoại không hợp lệ
                MessageBox.Show("Lương không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Đặt focus trở lại TextBox
                e.Cancel = true;
            }
        }
    }
}
