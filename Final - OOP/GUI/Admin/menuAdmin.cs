using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Final___OOP.AdminQLChungBUS;

namespace Final___OOP
{
    public partial class menuAdmin : Form
    {
        private AdminQLChungBUS adminQLChungBUS;
        private GetLopHocBUS lopHocBUS;
        private SinhVienBUS sinhVienBUS;
        private GiangVienBUS giangVienBUS;
        public menuAdmin()
        {
            InitializeComponent();
            lopHocBUS = new GetLopHocBUS();
            sinhVienBUS = new SinhVienBUS();
            giangVienBUS = new GiangVienBUS();
            
            //QL sinh viên
            GetAllSV();
            LoadDataCB();
            dtgvSinhVien.SelectionChanged += dtgvSinhVien_SelectionChanged;

            //QLGiangVien
            GetAllGV();
            dtgvGiangVien.SelectionChanged += dtgvGiangVien_SelectionChanged;

            //QLChung
            adminQLChungBUS = new AdminQLChungBUS();
            LoadDataMonHoc();
            DGVMon.CellClick += new DataGridViewCellEventHandler(DGVMon_CellClick);

            LoadDataLopHoc();
            DGVLop.CellClick += new DataGridViewCellEventHandler(DGVLop_CellClick);

            LoadDataMonHocChoChuong();
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;
            LoadDataChuong();
            DGVChuong.CellClick += DGVChuong_CellClick;


            //format:
            doitenDGV();


        }

        // Format


        private void doitenDGV()
        {
            //Khu vực Quản lý SV
            dtgvSinhVien.Columns["MaSV"].HeaderText = "Mã sinh viên";
            dtgvSinhVien.Columns["HoTen"].HeaderText = "Họ và tên";
            dtgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dtgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dtgvSinhVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dtgvSinhVien.Columns["TenLop"].HeaderText = "Lớp";


            //Khu vực Quản lý GV
            dtgvGiangVien.Columns["MaGV"].HeaderText = "Mã giảng viên";
            dtgvGiangVien.Columns["HoTen"].HeaderText = "Họ và tên";
            dtgvGiangVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dtgvGiangVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dtgvGiangVien.Columns["DiaChi"].HeaderText = "Địa chỉ";


            //Khu vực QLChung
            DGVMon.Columns["MaMH"].HeaderText = "Mã Môn Học";
            DGVMon.Columns["TenMH"].HeaderText = "Tên Môn Học";
            DGVLop.Columns["MaLop"].HeaderText = "Mã Lớp";
            DGVLop.Columns["TenLop"].HeaderText = "Tên Lớp";
            DGVChuong.Columns["MaChuong"].HeaderText = "Mã Chương";
            DGVChuong.Columns["TenChuong"].HeaderText = "Tên Chương";
            DGVChuong.Columns["MaMonHoc"].HeaderText = "Mã Môn Học";
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

                if (sinhVienBUS.IsValidSinhVienDataBUS(maSV, hoTenSV, ngaySinhSV, Lop, diaChi, email, gioiTinh))
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

                if (sinhVienBUS.IsValidSinhVienDataBUS(maSV, hoTenSV, ngaySinhSV, lop, diaChi, email, gioiTinh))
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
            var lsLopHoc = lopHocBUS.GetAllLopHoc();

            cbLop.DataSource = lsLopHoc;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "MaLop";
        }


        //Load danh sách sinh viên lên datagridview
        private void GetAllSV()
        {
            try
            {
                List<SinhVienView> danhSachSinhVien = sinhVienBUS.LayDanhSachSinhVien();

                dtgvSinhVien.DataSource = danhSachSinhVien;

                dtgvSinhVien.Columns["MaLop"].Visible = false;

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
        ////Chức năng Môn Học
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
                    LoadDataMonHocChoChuong();
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
                    LoadDataMonHocChoChuong();
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
                        LoadDataMonHocChoChuong();
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
                List<MonHocViewModel> danhSachMonHoc = adminQLChungBUS.LayDanhSachMonHocBUS();
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
            try
            {
                string maGV = txtMaGV.Text;
                string hoTenGV = txtHoTenGV.Text;
                DateTime ngaySinhGV = dtpNgaySinhGV.Value;
                string diaChiGV = txtDiaChiGV.Text;
                string emailGV = txtEmailGV.Text;
                bool gioiTinhGV = rbNuGV.Checked;
                if (giangVienBUS.IsValidGiangVienBUS(maGV, hoTenGV, ngaySinhGV, diaChiGV, emailGV, gioiTinhGV))
                {
                    giangVienBUS.AddGiangVienBUS(maGV, hoTenGV, ngaySinhGV, diaChiGV, emailGV, gioiTinhGV);
                    GetAllGV();
                    MessageBox.Show("Thêm giảng viên thành công ");
                }
                else
                {
                    MessageBox.Show("Thông tin chưa hợp lệ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm giảng viên: " + ex.Message);
            }
        }

        ////Chức năng Chương:
        private void DGVChuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = DGVChuong.Rows[e.RowIndex];

                string maChuong = selectedRow.Cells["MaChuong"].Value.ToString();
                string tenChuong = selectedRow.Cells["TenChuong"].Value.ToString();
                string maMonHoc = selectedRow.Cells["MaMonHoc"].Value.ToString();


                tbMaChuong.Text = maChuong;
                tbTenChuong.Text = tenChuong;


                if (cbMonHoc.Items.Cast<MonHocViewModel>().Any(item => item.MaMH == maMonHoc))
                {
                    cbMonHoc.SelectedValue = maMonHoc;
                }
                else
                {
                    cbMonHoc.SelectedIndex = -1;
                }
            }
        }
        private void LoadDataMonHocChoChuong()
        {
            List<MonHocViewModel> danhSachMonHoc = adminQLChungBUS.LayDanhSachMonHocBUS();
            cbMonHoc.DataSource = danhSachMonHoc;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
        }
        private void LoadDataChuong()
        {
            List<ChuongViewModel> danhSachChuong = adminQLChungBUS.LayDanhSachChuongBUS();
            DGVChuong.DataSource = danhSachChuong;
        }
        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataChuong();
        }
        private void ClearChuongInputs()
        {
            tbMaChuong.Clear();
            tbTenChuong.Clear();
            cbMonHoc.SelectedIndex = -1;
        }

        private void btnDelChuong_Click(object sender, EventArgs e)
        {
            try
            {
                string maChuong = tbMaChuong.Text;

                if (!string.IsNullOrEmpty(maChuong))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Chương này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        adminQLChungBUS.DeleteChuongBUS(maChuong);
                        LoadDataChuong();
                        MessageBox.Show("Xóa Chương thành công!");
                        ClearChuongInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Chương để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa Chương: " + ex.Message);
            }
        }

        private void btnChangeChuong_Click(object sender, EventArgs e)
        {
            try
            {
                string maChuong = tbMaChuong.Text;
                string tenChuong = tbTenChuong.Text;
                string maMonHoc = cbMonHoc.SelectedValue.ToString();

                if (!string.IsNullOrEmpty(maChuong) && !string.IsNullOrEmpty(tenChuong) && !string.IsNullOrEmpty(maMonHoc))
                {
                    adminQLChungBUS.UpdateChuongBUS(maChuong, tenChuong, maMonHoc);
                    LoadDataChuong();
                    MessageBox.Show("Cập nhật Chương thành công!");
                    ClearChuongInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Chương và nhập thông tin cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật Chương: " + ex.Message);
            }
        }

        private void btnAddChuong_Click(object sender, EventArgs e)
        {
            try
            {
                string maChuong = tbMaChuong.Text;
                string tenChuong = tbTenChuong.Text;
                // Kiểm tra giá trị MaMH trước khi lưu
                object selectedValue = cbMonHoc.SelectedValue;
                string maMonHoc = (selectedValue != null) ? selectedValue.ToString() : string.Empty;

                if (!string.IsNullOrEmpty(maChuong) && !string.IsNullOrEmpty(tenChuong) && !string.IsNullOrEmpty(maMonHoc))
                {
                    adminQLChungBUS.AddChuongBUS(maChuong, tenChuong, maMonHoc);
                    LoadDataChuong();
                    MessageBox.Show("Thêm Chương thành công!");
                    ClearChuongInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Chương.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Chương: " + ex.Message);
            }
        }

        ////Chức năng Lớp Học:
        private void DGVLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = DGVLop.Rows[e.RowIndex];

                string maLop = selectedRow.Cells["MaLop"].Value.ToString();
                string tenLop = selectedRow.Cells["TenLop"].Value.ToString();

                // Hiển thị thông tin trong TextBox
                tbMaLop.Text = maLop;
                tbTenLop.Text = tenLop;
            }
        }
        private void LoadDataLopHoc()
        {
            try
            {
                List<LopHocViewModel> danhSachLopHoc = adminQLChungBUS.LayDanhSachLopHocBUS();
                DGVLop.DataSource = danhSachLopHoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message);
            }
        }
        private void ClearLopHocInputs()
        {
            tbMaLop.Clear();
            tbTenLop.Clear();
        }
        private void btnDelLop_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = tbMaLop.Text;

                if (!string.IsNullOrEmpty(maLop))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Lớp Học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        adminQLChungBUS.DeleteLopHocBUS(maLop);
                        LoadDataLopHoc();
                        MessageBox.Show("Xóa Lớp Học thành công!");
                        ClearLopHocInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Lớp Học để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa Lớp Học: " + ex.Message);
            }
        }

        private void btnChangeLop_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = tbMaLop.Text;
                string tenLop = tbTenLop.Text;

                if (!string.IsNullOrEmpty(maLop) && !string.IsNullOrEmpty(tenLop))
                {
                    adminQLChungBUS.UpdateLopHocBUS(maLop, tenLop);
                    LoadDataLopHoc();
                    MessageBox.Show("Cập nhật Lớp Học thành công!");
                    ClearLopHocInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Lớp Học và nhập thông tin cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật Lớp Học: " + ex.Message);
            }
        }

        private void btnAddLop_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = tbMaLop.Text;
                string tenLop = tbTenLop.Text;

                if (!string.IsNullOrEmpty(maLop) && !string.IsNullOrEmpty(tenLop))
                {
                    adminQLChungBUS.AddLopHocBUS(maLop, tenLop);
                    LoadDataLopHoc();
                    MessageBox.Show("Thêm Lớp Học thành công!");
                    ClearLopHocInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Lớp Học.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Lớp Học: " + ex.Message);
            }
        }


        //Other
        private void btnSuaGV_Click(object sender, EventArgs e)
        {
            try
            {
                string maGV = txtMaGV.Text;
                string hoTenGV = txtHoTenGV.Text;
                DateTime ngaySinhGV = dtpNgaySinhGV.Value;
                string diaChiGV = txtDiaChiGV.Text;
                string emailGV = txtEmailGV.Text;
                bool gioiTinhGV = rbNuGV.Checked;
                if (giangVienBUS.IsValidGiangVienBUS(maGV, hoTenGV, ngaySinhGV, diaChiGV, emailGV, gioiTinhGV))
                {
                    giangVienBUS.UpdateGiangVienBUS(maGV, hoTenGV, ngaySinhGV, diaChiGV, emailGV, gioiTinhGV);
                    GetAllGV();
                    MessageBox.Show("Sửa giảng viên thành công ");
                }
                else
                {
                    MessageBox.Show("Thông tin chưa hợp lệ ");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm giảng viên: " + ex.Message);
            }
        }

        private void btnXoaGV_Click(object sender, EventArgs e)
        {
            try
            {
                string maGV = txtMaGV.Text;

                if (!string.IsNullOrEmpty(maGV))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        giangVienBUS.DeleteGiangVienBUS(maGV);
                        GetAllGV(); // Gọi phương thức để cập nhật danh sách giảng viên
                        MessageBox.Show("Xóa giảng viên thành công!");
                        GiangVienClearInputs(); // Thêm hàm này để xóa dữ liệu trong các controls
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một giảng viên để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa giảng viên: " + ex.Message);
            }
        }
        private void GiangVienClearInputs()
        {
            txtMaGV.Clear();
            txtHoTenGV.Clear();
            dtpNgaySinhGV.Value = DateTime.Now;
            txtDiaChiGV.Clear();
            txtEmailGV.Clear();
            rbNamGV.Checked = true;
            rbNuGV.Checked = false;
        }

        private void GetAllGV()
        {
            try
            {
                List<GiangVienView> DanhSachGV = giangVienBUS.GetGiangVienList();

                dtgvGiangVien.DataSource = DanhSachGV;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message);
            }
        }
        private void dtgvGiangVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvGiangVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgvGiangVien.SelectedRows[0];

                string maGV = selectedRow.Cells["MaGV"].Value.ToString();
                string hoTenGV = selectedRow.Cells["HoTen"].Value.ToString();
                DateTime ngaySinhGV = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                string diaChiGV = selectedRow.Cells["DiaChi"].Value.ToString(); ;
                string emailGV = selectedRow.Cells["Email"].Value.ToString();
                bool gioiTinhGV = Convert.ToBoolean(selectedRow.Cells["GioiTinh"].Value);

                txtMaGV.Text = maGV;
                txtHoTenGV.Text = hoTenGV;
                dtpNgaySinhGV.Value = ngaySinhGV;
                txtDiaChiGV.Text = diaChiGV;
                txtEmailGV.Text = emailGV;
                rbNamGV.Checked = !gioiTinhGV;
                rbNuGV.Checked = gioiTinhGV;
            }
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

        private void menuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (adminQLChungBUS != null)
                adminQLChungBUS.Dispose();
            if (lopHocBUS != null)
                lopHocBUS.Dispose();
            if (sinhVienBUS != null)
                sinhVienBUS.Dispose();
            if (giangVienBUS != null)
                giangVienBUS.Dispose();
        }


    }
}
