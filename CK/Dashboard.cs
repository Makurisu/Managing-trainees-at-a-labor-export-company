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

namespace CK
{
    public partial class Dashboard : Form
    {
        BUS_Class BUS_Class = new BUS_Class();
        BUS_Contract BUS_Contract = new BUS_Contract();
        BUS_HocVien BUS_HocVien = new BUS_HocVien();
        int month, year;
        public static int static_month, static_year;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            scheduleLB.Text = "Lịch trình tháng " + now.Month;
            displayDays();
            label7.Text = "Số lượng "+BUS_HocVien.countHocVien()+"";
            label4.Text = "Số lượng "+BUS_Contract.countContract() + "";
            label2.Text = "Số lượng "+BUS_Class.countClass() + "";
        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month= now.Month;
            year= now.Year;
            static_month = month;
            static_year = year;
            DateTime startofmonth = new DateTime(now.Year, now.Month, 1);
            int days = DateTime.DaysInMonth(now.Year, now.Month);
            int dayofweek = Convert.ToInt32(startofmonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayofweek; i++)
            {
                UserControl1 ucBlank = new UserControl1();
                ucBlank.Dock = DockStyle.Fill;
                tableLayoutPanel5.Controls.Add(ucBlank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControl2 ucDay = new UserControl2();
                ucDay.Dock = DockStyle.Fill;
                ucDay.days(i);
                tableLayoutPanel5.Controls.Add(ucDay);
            }
        }
    }
}
