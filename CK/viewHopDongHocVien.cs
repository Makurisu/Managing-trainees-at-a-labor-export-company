using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using BUS;
using DTO;

namespace CK
{
    public partial class viewHopDongHocVien : Form
    {
        BUS_studentContract studentContract = new BUS_studentContract();
        public viewHopDongHocVien()
        {
            InitializeComponent();
        }

        private void viewHopDongHocVien_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = studentContract.getStudentContract();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainDGV.SelectedRows[0];
            DTO_studentContract dtoStudentContract = new DTO_studentContract(DTO_Account.tempUsername, row.Cells[0].Value.ToString());
            if (studentContract.xoaStudentContract(dtoStudentContract))
            {
                this.Alert("Success Alert", Form_Alert.enmType.Success);
                mainDGV.DataSource = studentContract.getStudentContract();
            }
            else
            {
                
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            object a = searchCB.SelectedItem;
            string b = Convert.ToString(a);
            String type;
            if (b == "Mã hợp đồng")
            {
                type = "contract_id";
            }
            else
            {
                type = "student_id";
            }
            mainDGV.DataSource = studentContract.searchStudentContract(type, searchTB.Text);
        }
    }
}
