using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Adapters;
using Final___OOP.BUS;
using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using static Final___OOP.BUS.QLDeThiBUS;

namespace Final___OOP
{
    public partial class MenuTeacher : Form
    {
        private CauHoiBUS cauHoiBUS;
        private GetDeThiBUS dethiBUS;
        private TraCuuSinhVienBUS traCuuSinhVienBUS;
        private GetChungBUS getChungBUS;
        private QLDeThiBUS qLDeThiBUS;
        private void MenuTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(cauHoiBUS != null) { cauHoiBUS.Dispose(); }
            if(dethiBUS != null) { dethiBUS.Dispose(); }
            if(traCuuSinhVienBUS != null) { traCuuSinhVienBUS.Dispose(); }
            if(getChungBUS != null) { getChungBUS.Dispose(); }
            if(qLDeThiBUS != null) { qLDeThiBUS.Dispose(); }
        }
        public MenuTeacher()
        {
            InitializeComponent();
            
            cauHoiBUS = new CauHoiBUS();
            dethiBUS = new GetDeThiBUS();
            traCuuSinhVienBUS = new TraCuuSinhVienBUS();
            getChungBUS = new GetChungBUS();
            qLDeThiBUS = new QLDeThiBUS();

            LoadDataCB();
            GetAllCauHoi();


            //Tạo đề thi
            LoadDataCB_TaoDeThi();
            LoadDanhSachDeThi();

            doitenDGV();
        }
        private void doitenDGV()
        {
            /*gvDiem.Columns["MaSV"].HeaderText = "Mã sinh viên";*//*
            gvDiem.Columns["HoTen"].HeaderText = "Họ và tên";
            gvDiem.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            gvDiem.Columns["Lop"].HeaderText = "Lớp";
            gvDiem.Columns["Diem"].HeaderText = "Điểm";*/

            gvCauHoi.Columns["NoiDungCauHoi"].HeaderText = "Nội dung";
            gvCauHoi.Columns["DapAnA"].HeaderText = "Đáp án A";
            gvCauHoi.Columns["DapAnB"].HeaderText = "Đáp án B";
            gvCauHoi.Columns["DapAnC"].HeaderText = "Đáp án C";
            gvCauHoi.Columns["DapAnD"].HeaderText = "Đáp án D";
            gvCauHoi.Columns["DapAnDung"].HeaderText = "Đáo án đúng";
            gvCauHoi.Columns["MaMH"].HeaderText = "Mã môn";
            gvCauHoi.Columns["MaChuong"].HeaderText = "Mã chương";

/*            dtgvCauHoiDeThi.Columns["MaCauHoi"].HeaderText = "Mã câu hỏi";
            dtgvCauHoiDeThi.Columns["NoiDungCauHoi"].HeaderText = "Nội dung câu";
            dtgvCauHoiDeThi.Columns["DapAn_A"].HeaderText = "Đáp án A";
            dtgvCauHoiDeThi.Columns["DapAn_B"].HeaderText = "Đáp án B";
            dtgvCauHoiDeThi.Columns["DapAn_C"].HeaderText = "Đáp án C";
            dtgvCauHoiDeThi.Columns["DapAn_D"].HeaderText = "Đáp án D";
            dtgvCauHoiDeThi.Columns["DapAnDung"].HeaderText = "Đáo án đúng";*/

            DGVQLDeThi.Columns["MaDeThi"].HeaderText = "Mã đề thi";
            DGVQLDeThi.Columns["TenDeThi"].HeaderText = "Tên đề thi";
            DGVQLDeThi.Columns["TGLamBai"].HeaderText = "Thời gian";
            DGVQLDeThi.Columns["SoLuongCau"].HeaderText = "Số lượng câu";
            DGVQLDeThi.Columns["MaCB"].HeaderText = "Mã cán bộ";
            DGVQLDeThi.Columns["TenLop"].HeaderText = "Tên lớp";
            DGVQLDeThi.Columns["TenMH"].HeaderText = "Tên môn học";
        }
        void LoadDataCB()
        {
            var lsMonHoc = getChungBUS.GetAllMonHoc();

            cbMonHoc.DataSource = lsMonHoc;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
            cbMonHoc.SelectedIndexChanged += cbMonHoc_SelectedIndexChanged;
            cbMonHoc_SelectedIndexChanged(null, EventArgs.Empty);

            cbMonHocTraCuu.DataSource = lsMonHoc;
            cbMonHocTraCuu.DisplayMember = "TenMH";
            cbMonHocTraCuu.ValueMember = "MaMH";


            var lsLop = getChungBUS.GetAllLopHoc();
            cbLopHoc.DataSource = lsLop;
            cbLopHoc.DisplayMember = "TenLop";
            cbLopHoc.ValueMember = "MaLop";

            var lsDeThi = dethiBUS.GetAllDeThi();
            cbDeThi.DataSource = lsDeThi;
            cbDeThi.DisplayMember = "TenDeThi";
            cbDeThi.ValueMember = "MaDeThi";
        }
        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maMonHoc = cbMonHoc.SelectedValue.ToString();

            var lsChuong = getChungBUS.GetAllChuong(maMonHoc);

            cbChuong.DataSource = lsChuong;
            cbChuong.DisplayMember = "TenChuong";
            cbChuong.ValueMember = "MaChuong";
        }
        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            try
            {
                string maCauHoi = txtMaCauHoi.Text;
                string maMH = cbMonHoc.SelectedValue.ToString();
                string maChuong = cbChuong.SelectedValue.ToString();
                string noiDung = txtNoiDungCauHoi.Text.Trim();
                string dapAnA = txtDapAnA.Text;
                string dapAnB = txtDapAnB.Text;
                string dapAnC = txtDapAnC.Text;
                string dapAnD = txtDapAnD.Text;
                string dapAnDung = "";

                if (rdA.Checked) dapAnDung = "A";
                else if (rdB.Checked) dapAnDung = "B";
                else if (rdC.Checked) dapAnDung = "C";
                else if (rdD.Checked) dapAnDung = "D";

                if (!string.IsNullOrEmpty(maCauHoi) && !string.IsNullOrEmpty(maMH) && !string.IsNullOrEmpty(maChuong) && !string.IsNullOrEmpty(noiDung)
                    && !string.IsNullOrEmpty(dapAnA) && !string.IsNullOrEmpty(dapAnB) && !string.IsNullOrEmpty(dapAnC) && !string.IsNullOrEmpty(dapAnD) && !string.IsNullOrEmpty(dapAnDung))
                {
                    cauHoiBUS.AddCauHoiBUS(maCauHoi, noiDung, dapAnA, dapAnB, dapAnC,
            dapAnD, dapAnDung, maMH, maChuong);
                    MessageBox.Show("Thêm câu hỏi thành công!");
                    GetAllCauHoi();
                    ClearCauHoiInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin câu hỏi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm câu hỏi: " + ex.Message);
            }
        }
        private void GetAllCauHoi()
        {
            try
            {
                List<CauHoi> danhSachCauHoi = cauHoiBUS.LayDanhSachCauHoiBUS();
                gvCauHoi.DataSource = danhSachCauHoi;

                gvCauHoi.Columns["MaCauHoi"].Visible = false;
                gvCauHoi.Columns["Chuong"].Visible = false;
                gvCauHoi.Columns["MonHoc"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách câu hỏi: " + ex.Message);
            }
        }

        
        private void ClearCauHoiInputs()
        {
            txtMaCauHoi.Clear();
            txtNoiDungCauHoi.Clear();
            txtDapAnA.Clear();
            txtDapAnB.Clear();
            txtDapAnC.Clear();
            txtDapAnD.Clear();
            rdA.Checked = false;
            rdB.Checked = false;
            rdC.Checked = false;
            rdD.Checked = false;

        }

        private void ClearTraCuuDiemInputs()
        {
            gvDiem.DataSource = null;
        }

        private void btnXoaCauHoi_Click(object sender, EventArgs e)
        {
            try
            {
                string maCauHoi = txtMaCauHoi.Text;

                if (!string.IsNullOrEmpty(maCauHoi))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        cauHoiBUS.DeleteCauHoiBUS(maCauHoi);
                        MessageBox.Show("Xóa câu hỏi thành công!");
                        GetAllCauHoi();
                        ClearCauHoiInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một câu hỏi để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa câu hỏi: " + ex.Message);
            }
        }
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maCauHoi = txtMaCauHoi.Text;
                string maMH = cbMonHoc.SelectedValue.ToString();
                string maChuong = cbChuong.SelectedValue.ToString();
                string noiDung = txtNoiDungCauHoi.Text.Trim();
                string dapAnA = txtDapAnA.Text;
                string dapAnB = txtDapAnB.Text;
                string dapAnC = txtDapAnC.Text;
                string dapAnD = txtDapAnD.Text;
                string dapAnDung = "";

                if (rdA.Checked) dapAnDung = "A";
                else if (rdB.Checked) dapAnDung = "B";
                else if (rdC.Checked) dapAnDung = "C";
                else if (rdD.Checked) dapAnDung = "D";

                if (!string.IsNullOrEmpty(maCauHoi) && !string.IsNullOrEmpty(maMH) && !string.IsNullOrEmpty(maChuong) && !string.IsNullOrEmpty(noiDung)
                    && !string.IsNullOrEmpty(dapAnA) && !string.IsNullOrEmpty(dapAnB) && !string.IsNullOrEmpty(dapAnC) && !string.IsNullOrEmpty(dapAnD) && !string.IsNullOrEmpty(dapAnDung))
                {
                    cauHoiBUS.UpdateCauHoiBUS(maCauHoi, noiDung, dapAnA, dapAnB, dapAnC,
            dapAnD, dapAnDung, maMH, maChuong);
                    MessageBox.Show("Sửa thông tin câu hỏi thành công!");
                    GetAllCauHoi();
                    ClearCauHoiInputs();
                }
                else
                {
                    MessageBox.Show("Dữ liệu câu hỏi không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin câu hỏi: " + ex.Message);
            }
        }
        private void gvCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvCauHoi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = gvCauHoi.SelectedRows[0];

                string maCauHoi = selectedRow.Cells["MaCauHoi"].Value.ToString();
                string noiDung = selectedRow.Cells["NoiDungCauHoi"].Value.ToString();
                string dapAnA = selectedRow.Cells["DapAnA"].Value.ToString();
                string dapAnB = selectedRow.Cells["DapAnB"].Value.ToString();
                string dapAnC = selectedRow.Cells["DapAnC"].Value.ToString();
                string dapAnD = selectedRow.Cells["DapAnD"].Value.ToString();
                string maMH = selectedRow.Cells["MaMH"].Value.ToString();
                string maChuong = selectedRow.Cells["MaChuong"].Value.ToString();
                string dapAnDung = selectedRow.Cells["DapAnDung"].Value.ToString();

                if (dapAnDung == "A")
                    rdA.Checked = true;
                else if (dapAnDung == "B")
                    rdB.Checked = true;
                else if (dapAnDung == "C")
                    rdC.Checked = true;
                else
                    rdD.Checked = true;

                txtMaCauHoi.Text = maCauHoi;
                txtDapAnA.Text = dapAnA;
                txtDapAnB.Text = dapAnB;
                txtDapAnC.Text = dapAnC;
                txtDapAnD.Text = dapAnD;
                cbMonHoc.SelectedValue = maMH;
                cbChuong.SelectedValue = maChuong;
                txtNoiDungCauHoi.Text = noiDung;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maLopHoc = cbLopHoc.SelectedValue.ToString();
            string maMH = cbMonHocTraCuu.SelectedValue.ToString();
            string maDeThi = cbDeThi.SelectedValue.ToString();
            string maSV = txtMaSV.Text.Trim();

            GetDiemSV(maLopHoc, maMH, maDeThi, maSV);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ClearTraCuuDiemInputs();
        }

        private void btnXoaTim_Click(object sender, EventArgs e)
        {

        }




        //Tạo đề thi
        private void btnThemDETHI_Click(object sender, EventArgs e)
        {
            try
            {
                string maDeTHi = txtMDT_DeThi.Text;
                string tenDeThi = txtTen_DeThi.Text;
                string MaCB = Session.Instance.MaTK;

                int thoiGianLamBai = Convert.ToInt32(txtThoiGianLamBai.Text);

                TimeSpan TGLamBai = TimeSpan.FromMinutes(thoiGianLamBai);

                string maMH = CBMH_DeThi.SelectedValue.ToString();
                string maLop = CbLop_DeThi.SelectedValue.ToString();
                int soLuongCauHoi = 0;
                List<string> maCauHoiList = new List<string>();
                foreach (DataGridViewRow row in dtgvCauHoiDeThi.Rows)
                {
                    if (row.Cells["MaCauHoi"].Value != null)
                    {
                        string maCauHoi = row.Cells["MaCauHoi"].Value.ToString();
                        maCauHoiList.Add(maCauHoi);
                        soLuongCauHoi++;
                    }
                }

                string maCauHoiString = string.Join("|", maCauHoiList);

                // Thêm đề thi mới vào cơ sở dữ liệu
                qLDeThiBUS.ThemDeThiBUS(maDeTHi, tenDeThi, TGLamBai, maMH, maLop, maCauHoiString, soLuongCauHoi, MaCB);

                MessageBox.Show("Thêm đề thi thành công!");
                LoadDanhSachDeThi();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in btnThemDETHI_Click: {ex.Message}");
                MessageBox.Show($"Error in btnThemDETHI_Click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnFindQuestion_DeThi_Click(object sender, EventArgs e)
        {
            string maChuong = CBChuong_DeThi.SelectedValue.ToString();

            var dsCauHoi = qLDeThiBUS.GetCauHoiByChuongBUS(maChuong);

            dtgvCauHoi_DETHI.DataSource = dsCauHoi;
        }

        void LoadDataCB_TaoDeThi()
        {
            var lsLop = getChungBUS.GetAllLopHoc();
            CbLop_DeThi.DataSource = lsLop;
            CbLop_DeThi.DisplayMember = "TenLop";
            CbLop_DeThi.ValueMember = "MaLop";

            var lsMonHoc = getChungBUS.GetAllMonHoc();

            CBMH_DeThi.DataSource = lsMonHoc;
            CBMH_DeThi.DisplayMember = "TenMH";
            CBMH_DeThi.ValueMember = "MaMH";

            CBMH_DeThi.SelectedIndexChanged += CBMH_DeThi_SelectedIndexChanged;

            CBMH_DeThi_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void CBMH_DeThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maMonHoc = CBMH_DeThi.SelectedValue.ToString();

            var lsChuong = getChungBUS.GetAllChuong(maMonHoc);

            CBChuong_DeThi.DataSource = lsChuong;
            CBChuong_DeThi.DisplayMember = "TenChuong";
            CBChuong_DeThi.ValueMember = "MaChuong";
        }
        private void dtgvCauHoi_DETHI_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvCauHoi_DETHI.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgvCauHoi_DETHI.SelectedRows[0];
                string maCauHoi = selectedRow.Cells["MaCauHoi"].Value.ToString();

                DisplayInfoOnDtgvCauHoiDeThi(maCauHoi);
            }
        }
        private void DisplayInfoOnDtgvCauHoiDeThi(string maCauHoi)
        {
            var dsCauHoiDaChon = qLDeThiBUS.GetCauHoiBUS(maCauHoi);

            if (dtgvCauHoiDeThi.DataSource == null)
            {
                dtgvCauHoiDeThi.DataSource = dsCauHoiDaChon;
            }
            else
            {
                if (dsCauHoiDaChon.Any())
                {
                    var currentDataSource = (List<CauHoi_View>)dtgvCauHoiDeThi.DataSource;

                    if (currentDataSource == null)
                    {
                        currentDataSource = new List<CauHoi_View>();
                    }

                    foreach (var cauHoi in dsCauHoiDaChon)
                    {
                        if (!currentDataSource.Any(ch => ch.MaCauHoi == cauHoi.MaCauHoi))
                        {
                            currentDataSource.Add(cauHoi);
                        }
                    }

                    dtgvCauHoiDeThi.DataSource = null;
                    dtgvCauHoiDeThi.DataSource = currentDataSource;
                }
            }
        }
        
        //QL De Thi

        private void LoadDanhSachDeThi()
        {
            try
            {
                List<DeThiViewModel> danhSachDeThi = qLDeThiBUS.LayDanhSachDeThiBUS();
                DGVQLDeThi.DataSource = danhSachDeThi;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đề thi: " + ex.Message);
            }
        }
        

        //TracuuDiem
        private void GetDiemSV(string maLopHoc, string maMH, string maDeThi, string maSV)
        {
            try
            {
                List<TraCuuSinhVien> danhSachSV = traCuuSinhVienBUS.GetDanhSachSinhVien(maLopHoc, maMH, maDeThi, maSV);
                gvDiem.DataSource = danhSachSV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách câu hỏi: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maLopHoc = cbLopHoc.SelectedValue.ToString();
                string maMH = cbMonHocTraCuu.SelectedValue.ToString();
                string maDeThi = cbDeThi.SelectedValue.ToString();

                GetDiemSV(maLopHoc, maMH, maDeThi, maSV: null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy điểm sinh viên: " + ex.Message);
            }
        }

        //Chuyển pages
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

        private void dtgvCauHoiDeThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvCauHoiDeThi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgvCauHoiDeThi.SelectedRows[0];
                string maCauHoi = selectedRow.Cells["MaCauHoi"].Value.ToString();
                string noiDungCauHoi = selectedRow.Cells["NoiDungCauHoi"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có muốn xóa câu hỏi:\n\n{noiDungCauHoi}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var currentDataSource = (List<CauHoi_View>)dtgvCauHoiDeThi.DataSource;

                    var cauHoiToRemove = currentDataSource.FirstOrDefault(ch => ch.MaCauHoi == maCauHoi);
                    if (cauHoiToRemove != null)
                    {
                        currentDataSource.Remove(cauHoiToRemove);

                        dtgvCauHoiDeThi.DataSource = null;
                        dtgvCauHoiDeThi.DataSource = currentDataSource;
                    }
                }
            }
        }

    }
}
