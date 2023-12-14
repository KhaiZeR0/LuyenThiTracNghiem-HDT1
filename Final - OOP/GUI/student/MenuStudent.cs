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
    public partial class MenuStudent : Form
    {
        public MenuStudent()
        {
            InitializeComponent();
        }

        private void btnketquapage_Click(object sender, EventArgs e)
        {
            StudentPages.PageIndex = 2;
        }

        private void btnthipage_Click(object sender, EventArgs e)
        {
            StudentPages.PageIndex = 1;
        }
    }
}
