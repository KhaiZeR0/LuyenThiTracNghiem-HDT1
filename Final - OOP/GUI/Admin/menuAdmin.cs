using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___OOP
{
    public partial class menuAdmin : Form
    {
        public menuAdmin()
        {
            InitializeComponent();
        }

        private void btnQLSVpage_Click(object sender, EventArgs e)
        {
            AdminPages.PageIndex = 1;
        }

        private void btnQLGVpage_Click(object sender, EventArgs e)
        {
            AdminPages.PageIndex = 2;
        }

        private void btnchungpage_Click(object sender, EventArgs e)
        {
            AdminPages.PageIndex = 3;
        }
    }
}
