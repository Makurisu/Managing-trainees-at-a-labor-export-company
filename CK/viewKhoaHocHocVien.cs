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
    public partial class viewKhoaHocHocVien : Form
    {
        BUS_studentCourses studentCourses = new BUS_studentCourses();
        public viewKhoaHocHocVien()
        {
            InitializeComponent();
        }

        private void viewKhoaHocHocVien_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = studentCourses.getDetailStudentCourses();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainDGV.SelectedRows[0];
            DTO_studentCourses dtoStudentCourses = new DTO_studentCourses(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), "");
            if (studentCourses.xoaStudentCourses(dtoStudentCourses))
            {
                this.Alert("Success Alert", Form_Alert.enmType.Success);
                mainDGV.DataSource = studentCourses.getDetailStudentCourses();
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
            if (b == "Mã học viên")
            {
                type = "student_id";
            }
            else if (b == "Tên khóa học")
            {
                type = "course_name";
            }    
            else
            {
                type = "course_id";
            }
            mainDGV.DataSource = studentCourses.searcStudentCourses(type, searchTB.Text);
        }
    }
}
