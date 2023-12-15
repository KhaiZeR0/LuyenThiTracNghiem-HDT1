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
        private AdminQLChungBUS adminQLChungBUS;
        private GetLopHocBUS lopHocBUS;
        private SinhVienBUS sinhVienBUS;
        public menuAdmin()
        {
            InitializeComponent();
            lopHocBUS = new GetLopHocBUS();
            sinhVienBUS = new SinhVienBUS();

            //QL sinh viên
            GetAllSV();
            LoadDataCB();
            dtgvSinhVien.SelectionChanged += dtgvSinhVien_SelectionChanged;

            //QLChung
            adminQLChungBUS = new AdminQLChungBUS();
            LoadDataMonHoc();
            DGVMon.CellClick += new DataGridViewCellEventHandler(DGVMon_CellClick);
        }



        //Quản lý sinh viên
        //Chức năng thêm sinh viên mới
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
        
        
        //Chức năng sửa thông tin sinh viên
        private void btnSuaSV_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = txtMaSV.Text;
                string hoTenSV = txtHoTenSV.Text;
                DateTime ngaySinhSV = dtpNgaySinhSV.Value;
                string lop = cbLop.SelectedValue.ToString();
                string diaChi = txtDiaChiSV.Text;
                string email = txtEmailSV.Text;
                bool gioiTinh = rbNuSV.Checked;

                if (sinhVienBUS.IsValidSinhVienData(maSV, hoTenSV, ngaySinhSV, lop, diaChi, email, gioiTinh))
                {
                    sinhVienBUS.UpdateSinhVienBUS(maSV, hoTenSV, ngaySinhSV, lop, diaChi, email, gioiTinh);
                    GetAllSV();
                    MessageBox.Show("Sửa thông tin sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show("Dữ liệu sinh viên không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin sinh viên: " + ex.Message);
            }

        }

        //Chức năng xóa thông tin sinh viên
        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = txtMaSV.Text;

                if (!string.IsNullOrEmpty(maSV))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        sinhVienBUS.DeleteSinhVienBUS(maSV);
                        GetAllSV();
                        MessageBox.Show("Xóa sinh viên thành công!");
                        ClearInputs(); // Thêm hàm này để xóa dữ liệu trong các controls
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message);
            }
        }
        
        
        //Load danh sách lớp vào combobox ở quản lý sinh  viên
        void LoadDataCB()
        {
            List<Lophoc> lsLopHoc = lopHocBUS.GetAllLopHoc();

            cbLop.DataSource = lsLopHoc;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "MaLop";
        }


        //Load danh sách sinh viên lên datagridview
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
        
        //clear dữ liệu đầu vào sau khi thực hiện xóa thông tin sinh viên
        private void ClearInputs()
        {
            txtMaSV.Clear();
            txtHoTenSV.Clear();
            dtpNgaySinhSV.Value = DateTime.Now;
            cbLop.SelectedIndex = -1;
            txtDiaChiSV.Clear();
            txtEmailSV.Clear();
            rbNamSV.Checked = true;
            rbNuSV.Checked = false;
        }


        //Hiển thị thông tin của sinh viên lên bản thông tin input
        //khi click vào datagridview 
        private void dtgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvSinhVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgvSinhVien.SelectedRows[0];

                string maSV = selectedRow.Cells["MaSV"].Value.ToString();
                string hoTenSV = selectedRow.Cells["HoTen"].Value.ToString();
                DateTime ngaySinhSV = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                string lop = selectedRow.Cells["MaLop"].Value.ToString();
                string diaChi = selectedRow.Cells["DiaChi"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                bool gioiTinh = Convert.ToBoolean(selectedRow.Cells["GioiTinh"].Value);

                txtMaSV.Text = maSV;
                txtHoTenSV.Text = hoTenSV;
                dtpNgaySinhSV.Value = ngaySinhSV;
                cbLop.SelectedValue = lop;
                txtDiaChiSV.Text = diaChi;
                txtEmailSV.Text = email;
                rbNamSV.Checked = !gioiTinh;
                rbNuSV.Checked = gioiTinh;
            }
        }
        
        


        //Quản Lý Chung
        //Chức năng thêm Môn Học
        private void DGVMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = DGVMon.Rows[e.RowIndex];

                string maMon = selectedRow.Cells["MaMH"].Value.ToString();
                string tenMon = selectedRow.Cells["TenMH"].Value.ToString();

                // Hiển thị thông tin trong TextBox
                tbMaMon.Text = maMon;
                tbTenMon.Text = tenMon;
            }
        }
        private void btnAddMon_Click(object sender, EventArgs e)
        {
            try
            {
                string maMon = tbMaMon.Text;
                string tenMon = tbTenMon.Text;

                if (!string.IsNullOrEmpty(maMon) && !string.IsNullOrEmpty(tenMon))
                {
                    adminQLChungBUS.AddMonHocBUS(maMon, tenMon);
                    LoadDataMonHoc();
                    MessageBox.Show("Thêm Môn Học thành công!");
                    ClearMonHocInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Môn Học.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Môn Học: " + ex.Message);
            }
        }

        private void btnChangeMon_Click(object sender, EventArgs e)
        {
            try
            {
                string maMon = tbMaMon.Text;
                string tenMon = tbTenMon.Text;

                if (!string.IsNullOrEmpty(maMon) && !string.IsNullOrEmpty(tenMon))
                {
                    adminQLChungBUS.UpdateMonHocBUS(maMon, tenMon);
                    LoadDataMonHoc();
                    MessageBox.Show("Cập nhật Môn Học thành công!");
                    ClearMonHocInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Môn Học và nhập thông tin cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật Môn Học: " + ex.Message);
            }
        }

        private void btnDelMon_Click(object sender, EventArgs e)
        {
            try
            {
                string maMon = tbMaMon.Text;

                if (!string.IsNullOrEmpty(maMon))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Môn Học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        adminQLChungBUS.DeleteMonHocBUS(maMon);
                        LoadDataMonHoc();
                        MessageBox.Show("Xóa Môn Học thành công!");
                        ClearMonHocInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Môn Học để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa Môn Học: " + ex.Message);
            }
        }
        private void LoadDataMonHoc()
        {
            try
            {
                List<MonHoc> danhSachMonHoc = adminQLChungBUS.LayDanhSachMonHocBUS();
                DGVMon.DataSource = danhSachMonHoc;

                // Kiểm tra nếu không có dòng nào được chọn
                if (DGVMon.SelectedRows.Count == 0)
                {
                    ClearMonHocInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Môn Học: " + ex.Message);
            }
        }

        private void ClearMonHocInputs()
        {
            tbMaMon.Clear();
            tbTenMon.Clear();
        }

        private void btnThemGV_Click(object sender, EventArgs e)
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
