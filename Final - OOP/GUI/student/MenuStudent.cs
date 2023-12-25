using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using Final___OOP.DTO;
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
        private GetDSLopTuMaHSBUS getDSLopBUS;
        public MenuStudent()
        {
            InitializeComponent();
            getChungBUS = new GetChungBUS();
            thongTinThiCuBUS = new ThongTinThiCuBUS();
            getDSLopBUS = new GetDSLopTuMaHSBUS();

            //Trang thông tin thi cử
            loadCBMonHoc_DeThi();
        }
        private void btnFind_THI_Click(object sender, EventArgs e)
        {
            string maMH = cbMH_THI.SelectedValue.ToString();

            var lsDeThi = thongTinThiCuBUS.GetDeThiTheoMH_MaLopBUS(maMH, null);

            if (lsDeThi.Any())
            {
                DeThi firstDeThi = lsDeThi.First();

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
            if (cbDeThi_THI.SelectedItem != null)
            {
                string maDeThi = cbDeThi_THI.SelectedValue.ToString();

                BaiThiInfoDTO baiThiInfo = new BaiThiInfoDTO();
                DeThi selectedDeThi = (DeThi)cbDeThi_THI.SelectedItem;
                baiThiInfo.MaDeThi = selectedDeThi.MaDeThi;
                baiThiInfo.TGLamBai = selectedDeThi.TGLamBai;
                baiThiInfo.SoLuongCau = selectedDeThi.SoLuongCau;
                baiThiInfo.MaCauHoi = selectedDeThi.NoiDungDeThi;

                CourseScreen courseScreen = new CourseScreen(baiThiInfo);
                courseScreen.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đề thi trước khi bắt đầu thi.");
            }
        }


        void loadCBMonHoc_DeThi()
        {
            string maHS = Session.Instance.MaTK;
            var lsLop = getDSLopBUS.getDSLopBUS(maHS);
            var FirtDSLop = lsLop.FirstOrDefault();

            //List môn học
            var lsMon = getChungBUS.GetAllMonHoc();
            
            cbMH_THI.DataSource = lsMon;
            cbMH_THI.DisplayMember = "TenMH";
            cbMH_THI.ValueMember = "MaMH";

            //list đề thi thuộc môn học
            string MaMH = cbMH_THI.SelectedValue.ToString();
            
            if( FirtDSLop != null )
            {
                string maLop = FirtDSLop.MaLop;
                var lsDeThi = thongTinThiCuBUS.GetDeThiTheoMH_MaLopBUS(MaMH, maLop);

                cbDeThi_THI.DataSource = lsDeThi;
                cbDeThi_THI.DisplayMember = "TenDeThi";
                cbDeThi_THI.ValueMember = "MaDeThi";
            }
        }
        private void btnketquapage_Click(object sender, EventArgs e)
        {
            StudentPages.PageIndex = 1;
        }

        private void btnthipage_Click(object sender, EventArgs e)
        {
            StudentPages.PageIndex = 2;
        }

        private void MenuStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
