using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace CK
{
    public partial class contractRegister : Form
    {
        BUS_Contract busContract = new BUS_Contract();
        BUS_studentContract busStudentContract = new BUS_studentContract();
        public contractRegister()
        {
            InitializeComponent();
        }

        private void contractRegister_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = busContract.getContract();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void registerBT_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainDGV.SelectedRows[0];
            DTO_studentContract dtoStudentContract = new DTO_studentContract(DTO_Account.tempUsername, row.Cells[0].Value.ToString());
            if(busStudentContract.themStudentContract(dtoStudentContract))
            {
                this.Alert("Success Alert", Form_Alert.enmType.Success);
            }
            else
            {
                MessageBox.Show("Bạn đã đăng kí hợp đồng vui lòng vào trang cá nhân để kiểm tra!");
            }
        }
    }
}
