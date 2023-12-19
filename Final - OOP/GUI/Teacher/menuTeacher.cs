﻿using System;
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
        private GetMonHocBUS monHocBUS;
        private GetChuongBUS chuongBUS;
        private CauHoiBUS cauHoiBUS;
        private GetLopHocBUS lopHocBUS;
        private GetDeThiBUS dethiBUS;
        private TraCuuSinhVienBUS traCuuSinhVienBUS;
        public MenuTeacher()
        {
            InitializeComponent();
            monHocBUS = new GetMonHocBUS();
            chuongBUS = new GetChuongBUS();
            cauHoiBUS = new CauHoiBUS();
            lopHocBUS = new GetLopHocBUS();
            dethiBUS = new GetDeThiBUS();
            traCuuSinhVienBUS = new TraCuuSinhVienBUS();

            LoadDataCB();
            GetAllCauHoi();
        }

        //Load danh sách lớp vào combobox ở quản lý sinh  viên
        void LoadDataCB()
        {
            var lsMonHoc = monHocBUS.GetAllLopHoc();

            cbMonHoc.DataSource = lsMonHoc;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
            cbMonHocTraCuu.DataSource = lsMonHoc;
            cbMonHocTraCuu.DisplayMember = "TenMH";
            cbMonHocTraCuu.ValueMember = "MaMH";

            var lsChuong = chuongBUS.GetAllChuong();

            cbChuong.DataSource = lsChuong;
            cbChuong.DisplayMember = "TenChuong";
            cbChuong.ValueMember = "MaChuong";

            var lsLop = lopHocBUS.GetAllLopHoc();
            cbLopHoc.DataSource = lsLop;
            cbLopHoc.DisplayMember = "TenLop";
            cbLopHoc.ValueMember = "MaLop";

            var lsDeThi = dethiBUS.GetAllDeThi();
            cbDeThi.DataSource = lsDeThi;
            cbDeThi.DisplayMember = "TenDeThi";
            cbDeThi.ValueMember = "MaDeThi";
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

        private void gvCauHoi_SelectionChanged(object sender, EventArgs e)
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
