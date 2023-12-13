using Final___OOP.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final___OOP
{
    public partial class menuAdmin : Form
    {
        private GetAllLopHocBUS listLopHoc;
        public menuAdmin()
        {
            InitializeComponent();

            listLopHoc = new GetAllLopHocBUS();
            LoadData();  
        }
        void LoadData()
        {
            List<Lophoc> lsLopHoc = listLopHoc.GetAllLopHoc();

            cbLopSV.DataSource = lsLopHoc;
            cbLopSV.DisplayMember = "TenLop";
        }
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            string hoTenSV = txtTenSV.Text;
            DateTime ngaySinhSV = dtpNgaySinhSV.Value;
            string Lop = cbLopSV.Text;
            string diaChi = txtDiaChiSV.Text;
            string email = txtEmailSV.Text;


        }

        private void btnSuaSV_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {

        }

        private void btnchung_Click(object sender, EventArgs e)
        {
            ADpages.PageIndex = 3;
        }
    }
}
