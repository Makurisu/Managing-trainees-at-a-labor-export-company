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
using DAL;
using DTO;

namespace CK
{
    public partial class coursesRegister : Form
    {
        BUS_Class busClass = new BUS_Class();
        BUS_studentCourses busStudentCourses = new BUS_studentCourses();
        public coursesRegister()
        {
            InitializeComponent();
        }

        private void coursesRegister_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();

            // Đặt tên cho cột
            checkBoxColumn.Name = "MyCheckBoxColumn";
            checkBoxColumn.HeaderText = "Chọn";
            mainDGV.Columns.Add(checkBoxColumn);
            mainDGV.DataSource = busClass.getStudentClass(DTO_Account.tempUsername);
            checkBoxColumn.ReadOnly = false;
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void registerBT_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mainDGV.Rows)
            {
                if (Convert.ToBoolean(row.Cells["MyCheckBoxColumn"].Value))
                {
                    string column1Value = row.Cells["id"].Value.ToString();
                    DTO_studentCourses dtoStudentCourses = new DTO_studentCourses(DTO_Account.tempUsername, column1Value, "");
                    if(busStudentCourses.themStudentCourses(dtoStudentCourses))
                    {
                        this.Alert("Success Alert", Form_Alert.enmType.Success);
                    }    
                }
            }
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
            mainDGV.DataSource = busStudentCourses.searcStudentCourses(type, searchTB.Text);
        }
    }
}
