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
using System.Diagnostics;

namespace CK
{
    public partial class EventForm : Form
    {
        BUS_Calender calender = new BUS_Calender();
        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            dateTB.Text = Dashboard.static_month + "/" + UserControl2.static_day + "/" + Dashboard.static_year;
            eventTB.Text = calender.showEvent(Dashboard.static_month + "/" + UserControl2.static_day + "/" + Dashboard.static_year);
        }

        public delegate void UpdateDataEventHandler(object sender, EventArgs e);
        // Sự kiện
        public event UpdateDataEventHandler UpdateData;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DTO_Calender cld = new DTO_Calender(dateTB.Text, eventTB.Text);
            calender.addEvent(cld);
            UpdateData?.Invoke(this, e);
        }
    }
}
