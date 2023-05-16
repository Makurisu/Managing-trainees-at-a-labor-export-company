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
    public partial class Main_Student : Form
    {
        bool sidebarExpand = false;
        BUS_HocVien busHocVien = new BUS_HocVien();
        public Main_Student()
        {
            InitializeComponent();
        }

        private void timer1_tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
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

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            panel12.Show();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new coursesRegister());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new coursesRegisted());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new infoStudent());
        }

        private void logoutBT_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void Main_Student_Load(object sender, EventArgs e)
        {
            nameLB.Text = "Xin chào " + busHocVien.getNameHocVien(DTO_Account.tempUsername) + "";
            panel7.Hide();
            panel10.Hide();
            panel12.Hide();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (sidebarExpand == false)
            {
                timer1.Start();
                panel7.Show();
                panel10.Hide();
            }
            else
            {
                panel7.Show();
                panel10.Hide();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (sidebarExpand == false)
            {
                timer1.Start();
                panel7.Hide();
                panel10.Show();
            }
            else
            {
                panel7.Hide();
                panel10.Show();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(busHocVien.getStatusHocVien(DTO_Account.tempUsername))
            {
                openChildForm(new contractRegister());
            }    
            else
            {
                MessageBox.Show("Bạn chưa đủ điều kiện để ký hợp đồng!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new viewGrade());
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            openChildForm(new coursesRegisted());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildForm(new viewGrade());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (busHocVien.getStatusHocVien(DTO_Account.tempUsername))
            {
                openChildForm(new contractRegister());
            }
            else
            {
                MessageBox.Show("Bạn chưa đủ điều kiện để ký hợp đồng!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            activeForm.Close();
        }
    }
}
