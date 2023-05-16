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
    public partial class viewGrade : Form
    {
        BUS_Grade busGrade = new BUS_Grade();
        public viewGrade()
        {
            InitializeComponent();
        }

        private void viewGrade_Load(object sender, EventArgs e)
        {
            mainDGV.DataSource = busGrade.getGradeById(DTO_Account.tempUsername);
        }
    }
}
