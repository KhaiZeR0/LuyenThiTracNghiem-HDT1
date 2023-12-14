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
using static Final___OOP.BUS.SinhVienBUS;

namespace Final___OOP
{
    public partial class menuAdmin : Form
    {
        private GetLopHocBUS lopHocBUS;
        private SinhVienBUS sinhVienBUS;
        public menuAdmin()
        {
            InitializeComponent();
            lopHocBUS = new GetLopHocBUS();
            sinhVienBUS = new SinhVienBUS();

            GetAllSV();
            LoadDataCB();
        }
        void LoadDataCB()
        {
            List<Lophoc> lsLopHoc = lopHocBUS.GetAllLopHoc();

            cbLop.DataSource = lsLopHoc;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "MaLop";
        }
        private void GetAllSV()
        {
            try
            {
                List<SinhVienViewModel> danhSachSinhVien = sinhVienBUS.LayDanhSachSinhVien();

                dtgvSinhVien.DataSource = danhSachSinhVien;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message);
            }
        }
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = txtMaSV.Text;
                string hoTenSV = txtHoTenSV.Text;
                DateTime ngaySinhSV = dtpNgaySinhSV.Value;
                string Lop = cbLop.SelectedValue.ToString();
                string diaChi = txtDiaChiSV.Text;
                string email = txtEmailSV.Text;
                bool gioiTinh = rbNuSV.Checked;

                // Gọi phương thức của BUS để thêm sinh viên
                if (sinhVienBUS.IsValidSinhVienData(maSV, hoTenSV, ngaySinhSV, Lop, diaChi, email, gioiTinh))
                {
                    sinhVienBUS.AddSinhVienBUS(maSV, hoTenSV, ngaySinhSV, Lop, diaChi, email, gioiTinh);
                    GetAllSV();
                    MessageBox.Show("Thêm sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show("Dữ liệu sinh viên không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message);
            }
        }
        private void btnSuaSV_Click(object sender, EventArgs e)
        {

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
