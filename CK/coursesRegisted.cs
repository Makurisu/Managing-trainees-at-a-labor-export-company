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
    public partial class coursesRegisted : Form
    {
        BUS_studentCourses studentCourses = new BUS_studentCourses();
        public coursesRegisted()
        {
            InitializeComponent();
        }

        private void courseRegisted_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = studentCourses.getStudentCourses(DTO_Account.tempUsername);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            object a = searchCB.SelectedItem;
            string b = Convert.ToString(a);
            String type;
            if (b == "Tên khóa học")
            {
                type = "course_name";
            }
            else
            {
                type = "course_id";
            }
            mainDGV.DataSource = studentCourses.searcStudentCourses(DTO_Account.tempUsername, type, searchTB.Text);
        }
    }
}
