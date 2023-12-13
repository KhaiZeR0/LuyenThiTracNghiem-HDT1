using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___OOP.winform.student
{
    public partial class Menu_student : Form
    {
        public Menu_student()
        {
            InitializeComponent();
        }

        private void btnthipages_Click(object sender, EventArgs e)
        {
            studentPages.PageIndex = 2;
        }

        private void btnketquapage_Click(object sender, EventArgs e)
        {
            studentPages.PageIndex = 1;
        }
    }
}
