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

namespace CK
{
    public partial class viewContractRegisted : Form
    {
        BUS_studentContract busStudentContract = new BUS_studentContract();
        public viewContractRegisted()
        {
            InitializeComponent();
        }

        private void viewContractRegisted_Load(object sender, EventArgs e)
        {
            DataTable studentContract = busStudentContract.getStudentContract(DTO_Account.tempUsername);
            nameTB.Text = studentContract.Rows[0][0].ToString();
            countryTB.Text = studentContract.Rows[0][1].ToString();
            nhomnganhTB.Text = studentContract.Rows[0][2].ToString();
            nghenghiepTB.Text = studentContract.Rows[0][3].ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
