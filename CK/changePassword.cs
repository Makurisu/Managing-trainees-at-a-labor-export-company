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
    public partial class changePassword : Form
    {
        BUS_Account busAccount = new BUS_Account();
        public changePassword()
        {
            InitializeComponent();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(passTB.Text == rpassTB.Text)
            {
                if(busAccount.checkPassword(DTO_Account.tempUsername, curpassTB.Text, passTB.Text))
                {
                    this.Alert("Success Alert", Form_Alert.enmType.Success);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu hiện tại không chính xác");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không khớp");
            }
        }
    }
}
