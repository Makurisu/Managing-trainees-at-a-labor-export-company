using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK
{
    public partial class Notice : UserControl
    {
        public Notice()
        {
            InitializeComponent();
        }

        private void Notice_Load(object sender, EventArgs e)
        {

        }

        public void displayNotice(string notice, string date_post) 
        {
            noticeLB.Text = notice;
            datepostLB.Text = date_post;
        }
    }
}
