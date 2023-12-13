using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___OOP.winform.Teacher
{
    public partial class menuTeacher : Form
    {
        public menuTeacher()
        {
            InitializeComponent();
        }

        private void btntracuu_Click(object sender, EventArgs e)
        {
            teacherPages.PageIndex = 1;
        }

        private void btnQLCHpage_Click(object sender, EventArgs e)
        {
            teacherPages.PageIndex = 2;
        }

        private void btndethipage_Click(object sender, EventArgs e)
        {
            teacherPages.PageIndex = 3;
        }
    }
}
