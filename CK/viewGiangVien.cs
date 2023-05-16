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

namespace CK
{
    public partial class viewGiangVien : Form
    {
        BUS_GiangVien busGiangVien = new BUS_GiangVien();
        public viewGiangVien()
        {
            InitializeComponent();
        }

        private void viewGiangVien_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = busGiangVien.getGiangVien();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            object a = searchCB.SelectedItem;
            string b = Convert.ToString(a);
            String type;
            if (b == "Tên giảng viên")
            {
                type = "full_name";
            }
            else
            {
                type = "id";
            }
            mainDGV.DataSource = busGiangVien.searchGiangVien(type, searchTB.Text);
        }
    }
}
