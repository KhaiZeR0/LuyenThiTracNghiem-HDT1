﻿using System;
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
    public partial class MenuTeacher : Form
    {
        public MenuTeacher()
        {
            InitializeComponent();
        }

        private void btnFindQuestion_DeThi_Click(object sender, EventArgs e)
        {

        }

        private void btnQLCHpage_Click(object sender, EventArgs e)
        {
            TeacherPages.PageIndex = 2;
        }

        private void btntracuupage_Click(object sender, EventArgs e)
        {
            TeacherPages.PageIndex = 1;
        }

        private void btntaopage_Click(object sender, EventArgs e)
        {
            TeacherPages.PageIndex = 3;
        }

        private void btnQLDeThiPage_Click(object sender, EventArgs e)
        {
            TeacherPages.PageIndex = 4;
        }
    }
}
