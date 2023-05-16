using DTO;
using BUS;
namespace CK
{
    public partial class Login : Form
    {
        BUS_Account busAccount = new BUS_Account();
        string account;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2ToggleSwitch1.Checked)
            {
                label1.ForeColor = Color.White;
                label1.BackColor = Color.Black;
                label2.ForeColor = Color.White;
                label2.BackColor = Color.Black;
                label3.ForeColor = Color.White;
                label3.BackColor = Color.Black;
                label4.ForeColor = Color.White;
                label4.BackColor = Color.Black;
                this.BackColor = Color.Black;
                label4.Text = "Light mode";
            }    
            else
            {
                label1.ForeColor = Color.Black;
                label1.BackColor = Color.White;
                label2.ForeColor = Color.Black;
                label2.BackColor = Color.White;
                label3.ForeColor = Color.Black;
                label3.BackColor = Color.White;
                label4.ForeColor = Color.Black;
                label4.BackColor = Color.White;
                this.BackColor = Color.White;
                label4.Text = "Dark mode";
            }    
        }

        private void loginBt_Click(object sender, EventArgs e)
        {
            if(usernameTB.Text == "admin" && passTB.Text == "admin")
            {
                this.Hide();
                new Main().Show();
            }
            else
            {
                if(busAccount.getType(usernameTB.Text, passTB.Text) == 1)
                {
                    DTO_Account.tempUsername = usernameTB.Text;
                    this.Hide();
                    new Main_Student().Show();
                }    
                else if(busAccount.getType(usernameTB.Text, passTB.Text) == 1)
                {

                }    
                else { MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác"); }
                
            }
        }

        private void loginBt_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}