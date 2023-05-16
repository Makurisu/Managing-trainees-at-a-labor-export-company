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
    public partial class UserControl2 : UserControl
    {
        BUS_Calender calender = new BUS_Calender();
        public static string static_day;
        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            static_day = label1.Text;
            displayEvent();
        }

        public void days(int days) 
        {
            label1.Text = days + "";
        }

        private void UserControl2_Click(object sender, EventArgs e)
        {
            static_day = label1.Text;
            timer1.Start();
            EventForm eventForm = new EventForm();
            eventForm.UpdateData += UpdateData;
            eventForm.ShowDialog();
        }

        private void UpdateData(object sender, EventArgs e)
        {
            static_day = label1.Text;
            displayEvent();
        }

        public void displayEvent()
        {
            eventLB.Text = calender.showEvent(Dashboard.static_month + "/" + static_day + "/" + Dashboard.static_year);
        }
    }
}
