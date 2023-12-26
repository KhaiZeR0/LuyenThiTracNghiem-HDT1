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


            //Trang thông tin tra cứu
            loadCBTraCuu();
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
        void loadCBTraCuu()
        {   
            //lấy mã tài khoản học sinh đang đăng nhập
            string maHS = Session.Instance.MaTK;
            var lsLop = getDSLopBUS.getDSLopBUS(maHS);
            var FirtDSLop = lsLop.FirstOrDefault();

            //list môn học
            var lsMon = getChungBUS.GetAllMonHoc();

            cbMH_TraCuu.DataSource = lsMon;
            cbMH_TraCuu.DisplayMember = "TenMH";
            cbMH_TraCuu.ValueMember = "MaMH";

            string MaMH = cbMH_TraCuu.SelectedValue.ToString();
            if( FirtDSLop != null )
            {
                string maLop = FirtDSLop.MaLop;
                var lsDeThi = thongTinThiCuBUS.GetDeThiDaLamTheoMaSV(maHS);
                
                cbBaiThi_TraCuu.DataSource= lsDeThi;
                cbBaiThi_TraCuu.DisplayMember = "TenDeThi";
                cbBaiThi_TraCuu.ValueMember = "MaDeThi";
            }
        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string maHS = Session.Instance.MaTK;
            string maBaiThi = cbBaiThi_TraCuu.SelectedValue.ToString();

            List<BaiLam> lsbailam = thongTinThiCuBUS.getBaiLam(maHS, maBaiThi);

            loadBtnCauHoi_TraCuu(lsbailam);
        }

        void loadBtnCauHoi_TraCuu(List<BaiLam> lsbailam)
        {
            flpCauHoi.Controls.Clear();

            foreach (var baiLam in lsbailam)
            {
                // Mã câu hỏi và đáp án đã chọn từ bài làm
                string maBaiLam = baiLam.MaBaiLam;
                string dapAnDaChon = baiLam.DapAnDaChon;

                // Tách mã câu hỏi và đáp án đã chọn thành mảng
                string[] cauHoiArray = maBaiLam.Split('|');
                string[] dapAnArray = dapAnDaChon.Split('|');

                for (int i = 0; i < cauHoiArray.Length; i++)
                {
                    // Lấy mã câu hỏi và đáp án đã chọn
                    var maCauHoiItem = cauHoiArray[i];
                    var dapAnItem = dapAnArray.Length > i ? dapAnArray[i] : ""; // Đảm bảo không lỗi nếu số lượng đáp án không đủ

                    Button btnCauHoi = new Button();
                    btnCauHoi.Text = $"Câu {i + 1}";
                    btnCauHoi.Tag = maCauHoiItem; // Mã câu hỏi sẽ là Tag của nút
                    btnCauHoi.Click += btnCauHoi_Click;

                    // Đặt màu nền cho nút dựa trên việc đã chọn đáp án hay chưa
                    if (dapAnItem != "")
                    {
                        // Nếu đã chọn đáp án, đặt màu nền là màu khác nhau
                        btnCauHoi.BackColor = Color.LightGreen;
                    }

                    flpCauHoi.Controls.Add(btnCauHoi);
                }
            }
        }

        private void btnCauHoi_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi click vào nút câu hỏi
            Button btnCauHoi = (Button)sender;
            string maCauHoi = btnCauHoi.Tag.ToString();

            // Gọi hàm để hiển thị nội dung câu hỏi và đáp án
            HienThiThongTinCauHoi(maCauHoi);
        }

        private void HienThiThongTinCauHoi(string maCauHoi)
        {
            // Tạo đối tượng DbContext để truy cập cơ sở dữ liệu
            using (var dbContext = new ThiTracNghiemEntities())
            {
                // Lấy thông tin của câu hỏi từ cơ sở dữ liệu
                var cauHoi = dbContext.CauHois.SingleOrDefault(ch => ch.MaCauHoi == maCauHoi);

                // Hiển thị nội dung câu hỏi vào lbCauHoi_TraCuu
                lbCauHoi_TraCuu.Text = cauHoi.NoiDungCauHoi;

                // Hiển thị các câu trả lời vào các RadioButton
                rbDapAn_A.Text = $"A. {cauHoi.DapAnA}";
                rbDapAn_B.Text = $"B. {cauHoi.DapAnB}";
                rbDapAn_C.Text = $"C. {cauHoi.DapAnC}";
                rbDapAn_D.Text = $"D. {cauHoi.DapAnD}";
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
