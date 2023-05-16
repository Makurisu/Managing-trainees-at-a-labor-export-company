using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK
{
    public partial class Main : Form
    {
        bool sidebarExpand = true;
        public Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Width -= 10;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                panel1.Width -= 10;
                if (panel1.Width == panel1.MinimumSize.Width) 
                {
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                panel1.Width += 10;
                if (panel1.Width == panel1.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel5.Hide();
            panel7.Hide();
            panel10.Hide();
            panel12.Hide();
            openChildForm(new Dashboard());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel4.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel7.Hide();
            panel10.Show();
            panel12.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel7.Hide();
            panel10.Hide();
            panel12.Show();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void openDetailForm(Form childForm)
        {
            openChildForm(new detailStudent());
            //childForm.TopLevel = false;
            panelChildForm.Controls.Clear();
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            //panelChildForm.Controls.Add(childForm);
            //panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new addStudent());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            label1.Text = "Quản lý học viên";
            if (sidebarExpand == false)
            {
                timer1.Start();
                panel7.Show();
                panel10.Hide();
                panel12.Hide();
            }
            else
            {
                panel7.Show();
                panel10.Hide();
                panel12.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new viewStudent());
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            panel7.Hide();
            panel10.Hide();
            panel12.Hide();
            timer1.Start();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            label1.Text = "Quản lý hợp đồng";
            if (sidebarExpand == false)
            {
                timer1.Start();
                panel5.Hide();
                panel7.Hide();
                panel10.Show();
                panel12.Hide();
            }
            else
            {
                panel5.Hide();
                panel7.Hide();
                panel10.Show();
                panel12.Hide();
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            label1.Text = "Quản lý giảng viên";
            if (sidebarExpand == false)
            {
                timer1.Start();
                panel5.Hide();
                panel7.Hide();
                panel10.Hide();
                panel12.Show();
            }
            else
            {
                panel5.Hide();
                panel7.Hide();
                panel10.Hide();
                panel12.Show();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            label1.Text = "Quản lý khóa học";
            if (sidebarExpand == false)
            {
                timer1.Start();
                panel5.Show();
                panel7.Hide();
                panel10.Hide();
                panel12.Hide();
            }
            else
            {
                panel5.Show();
                panel7.Hide();
                panel10.Hide();
                panel12.Hide();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new addContract());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new addClass());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openChildForm(new addGiangVien());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openChildForm(new viewHopDongHocVien());
        }

        private void logoutBT_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new viewKhoaHocHocVien());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            openChildForm(new viewGiangVien());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new viewCoursesGrade());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard());
        }
    }
}
