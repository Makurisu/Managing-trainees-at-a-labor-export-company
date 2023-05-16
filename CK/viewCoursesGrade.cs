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
using BUS;
using DTO;

namespace CK
{
    public partial class viewCoursesGrade : Form
    {
        BUS_Grade busGrade = new BUS_Grade();
        public viewCoursesGrade()
        {
            InitializeComponent();
        }

        private void viewCoursesGrade_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = busGrade.getGrade();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainDGV.SelectedRows[0];
            DTO_Grade dtoGrade = new DTO_Grade(row.Cells[3].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString());
            if (busGrade.suaGrade(dtoGrade))
            {
                this.Alert("Success Alert", Form_Alert.enmType.Success);
                mainDGV.DataSource = busGrade.getGrade();
            }
            else
            {
                MessageBox.Show("Bạn đã đăng kí hợp đồng vui lòng vào trang cá nhân để kiểm tra!");
            }
        }

        private bool IsValidGrade(string grade)
        {
            string pattern = @"^10(\.0)?|([0-9](\.\d)?)$";
            return Regex.IsMatch(grade, pattern);
        }

        private void mainDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
            {
                string input = e.FormattedValue.ToString();
                if (!IsValidGrade(input))
                {
                    e.Cancel = true;
                    MessageBox.Show("Vui lòng chỉ nhập số nguyên.");
                }
            }
        }
    }
}
