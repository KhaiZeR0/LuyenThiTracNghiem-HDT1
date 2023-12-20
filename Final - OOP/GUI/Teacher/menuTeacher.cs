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

namespace Final___OOP
{
    public partial class MenuTeacher : Form
    {
        private CauHoiBUS cauHoiBUS;
        private GetDeThiBUS dethiBUS;
        private TraCuuSinhVienBUS traCuuSinhVienBUS;
        private GetChungBUS getChungBUS;
        private QLDeThiBUS qLDeThiBUS;

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
        }

        //Load danh sách lớp vào combobox ở quản lý sinh  viên
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

        private void GetDiemSV(string maLopHoc, string maMH, string maDeThi, string maSV)
        {
            try
            {
                List<TraCuuSinhVien> danhSachSV = traCuuSinhVienBUS.GetAllTraCuuSinhVien(maLopHoc, maMH, maDeThi, maSV);
                gvDiem.DataSource = danhSachSV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách câu hỏi: " + ex.Message);
            }
        }

        private void LoadDataCauHoi()
        {
            try
            {
                List<CauHoi> danhSachCauHoi = cauHoiBUS.LayDanhSachCauHoiBUS();
                gvCauHoi.DataSource = danhSachCauHoi;

                // Kiểm tra nếu không có dòng nào được chọn
                if (gvCauHoi.SelectedRows.Count == 0)
                {
                    ClearCauHoiInputs();
                }
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

        private void btnThhoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                qLDeThiBUS.ThemDeThiBUS(maDeTHi, tenDeThi, TGLamBai, maMH, maLop, maCauHoiString, soLuongCauHoi);

                MessageBox.Show("Thêm đề thi thành công!");
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
        private void dtgvCauHoiDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtgvCauHoiDeThi.Rows[e.RowIndex];
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

        
    }
}
