using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using System;
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
    public partial class MenuStudent : Form
    {
        private GetChungBUS getChungBUS;
        private ThongTinThiCuBUS thongTinThiCuBUS;
        public MenuStudent()
        {
            InitializeComponent();
            getChungBUS = new GetChungBUS();
            thongTinThiCuBUS = new ThongTinThiCuBUS();

            //Trang thông tin thi cử
            loadCBMonHoc_DeThi();
        }
        private void btnFind_THI_Click(object sender, EventArgs e)
        {
            string maMH = cbMH_THI.SelectedValue.ToString();

            var lsDeThi = thongTinThiCuBUS.GetDeThiTheoMonHocBUS(maMH);

            if (lsDeThi.Any())
            {
                // Chọn phần tử đầu tiên từ danh sách
                DeThi firstDeThi = lsDeThi.First();

                // Hiển thị thông tin từ phần tử đầu tiên vào các Label
                lbDeThi_THI.Text = $"Bài thi: {firstDeThi.TenDeThi}";
                lbSLCauHoi_THI.Text = $"Số lượng câu hỏi: {firstDeThi.SoLuongCau} câu";
                lbThoiGianLamBai_THi.Text = $"Thời gian làm bài: {firstDeThi.TGLamBai} ";
                lbGhiChu.Text = $"Ghi chú: ";
            }
            else
            {
                MessageBox.Show("Không có Đề Thi nào cho môn học này.");
            }
        }
        private void btnThi_THI_Click(object sender, EventArgs e)
        {
            string maDeThi = cbDeThi_THI.SelectedValue.ToString();


        }

        void loadCBMonHoc_DeThi()
        {
            //List môn học
            var lsMon = getChungBUS.GetAllMonHoc();
            
            cbMH_THI.DataSource = lsMon;
            cbMH_THI.DisplayMember = "TenMH";
            cbMH_THI.ValueMember = "MaMH";

            //list đề thi thuộc môn học
            string MaMH = cbMH_THI.SelectedValue.ToString();
            var lsDeThi = thongTinThiCuBUS.GetDeThiTheoMonHocBUS(MaMH);

            cbDeThi_THI.DataSource = lsDeThi;
            cbDeThi_THI.DisplayMember = "TenDeThi";
            cbDeThi_THI.ValueMember = "MaDeThi";
        }
        private void btnketquapage_Click(object sender, EventArgs e)
        {
            StudentPages.PageIndex = 2;
        }

        private void btnthipage_Click(object sender, EventArgs e)
        {
            StudentPages.PageIndex = 1;
        }

        private void MenuStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
