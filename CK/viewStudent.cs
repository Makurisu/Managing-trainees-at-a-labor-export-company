using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CK
{
    public partial class viewStudent : Form
    {
        BUS_HocVien busHV = new BUS_HocVien();
        Main detail = new Main();
        public viewStudent()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = busHV.getHocVien();
            while(searchTB.Text != "")
            {
                MessageBox.Show("aa");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainDGV.SelectedRows[0];
            DTO_Hocvien dtoHV = new DTO_Hocvien(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString());
            detailStudent detail = new detailStudent();
            detail.UpdateData += UpdateData;
            detail.detailHV(dtoHV);
            detail.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            object a = searchCB.SelectedItem;
            string b = Convert.ToString(a);
            String type;
            if(b=="Tên học viên")
            {
                type = "full_name";
            }
            else
            {
                type = "id";
            }
            mainDGV.DataSource = busHV.searchHocVien(type, searchTB.Text);
        }
        public void updateDGV(object sender, EventArgs e)
        {
            mainDGV.DataSource = busHV.getHocVien();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainDGV.SelectedRows[0];
            if (busHV.xoaHocVien(row.Cells[0].Value.ToString()))
                this.Alert("Success Alert", Form_Alert.enmType.Success);
            else
                this.Alert("Error Alert", Form_Alert.enmType.Error);
            mainDGV.DataSource = busHV.getHocVien();
        }
        private void UpdateData(object sender, EventArgs e)
        {
            mainDGV.DataSource = busHV.getHocVien();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Tạo một Worksheet mới
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                // Thêm tiêu đề cho các cột
                for (int i = 1; i <= mainDGV.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = mainDGV.Columns[i - 1].HeaderText;
                }

                // Thêm dữ liệu vào các ô trong Worksheet
                for (int i = 0; i < mainDGV.Rows.Count; i++)
                {
                    for (int j = 0; j < mainDGV.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = mainDGV.Rows[i].Cells[j].Value;
                    }
                }

                string filePath = @"C:\Users\Admin\Documents\data\a.xlsx";
                // Lưu dữ liệu vào file Excel
                File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());
            }
        }
    }
}
