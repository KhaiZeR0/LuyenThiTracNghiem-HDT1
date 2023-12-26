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
        private GetDeThiBUS getDeThiBUS;
        private BaiThiBUS getBaiThiBUS;

        public MenuStudent()
        {
            InitializeComponent();
            getChungBUS = new GetChungBUS();
            thongTinThiCuBUS = new ThongTinThiCuBUS();
            getDSLopBUS = new GetDSLopTuMaHSBUS();
            getDeThiBUS = new GetDeThiBUS();
            getBaiThiBUS = new BaiThiBUS();

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
                string maHS = Session.Instance.MaTK;
                string maBaiThi = cbBaiThi_TraCuu.SelectedValue.ToString();

                List<BaiLam> lsbailam = thongTinThiCuBUS.getBaiLam(maHS, maBaiThi);
                List<DeThi> DeThiList = getDeThiBUS.GetAllDeThi();

                DeThi deThi = DeThiList.Find(d => d.MaDeThi == maBaiThi);
                if (deThi != null)
                {
                    // Kiểm tra xem bài làm đã được hoàn thành chưa
                    if (lsbailam[0].TrangThai)
                    {
                        MessageBox.Show("Bạn đã hoàn thành bài thi này. Bạn không thể làm lại bài thi.");
                        return;
                    }

                    string cauHoiDeThi = deThi.NoiDungDeThi;
                    LoadBtnCauHoi_TraCuu(lsbailam, cauHoiDeThi);

                    BaiThiInfoDTO baiThiInfo = new BaiThiInfoDTO();
                    baiThiInfo.MaDeThi = deThi.MaDeThi;
                    baiThiInfo.TGLamBai = deThi.TGLamBai;
                    baiThiInfo.SoLuongCau = deThi.SoLuongCau;
                    baiThiInfo.MaCauHoi = deThi.NoiDungDeThi;

                    CourseScreen courseScreen = new CourseScreen(baiThiInfo);
                    courseScreen.Show();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một đề thi trước khi bắt đầu thi.");
                }
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
            List<DeThi> DeThiList = getDeThiBUS.GetAllDeThi();

            DeThi deThi = DeThiList.Find(d => d.MaDeThi == maBaiThi);
            if (deThi != null)
            {
                string cauHoiDeThi = deThi.NoiDungDeThi;
                LoadBtnCauHoi_TraCuu(lsbailam, cauHoiDeThi);

                // Khởi tạo số câu đúng và điểm
                int soCauDung = 0;
                double diem = 0;

                // Tính tổng số câu hỏi trong đề
                int tongSoCauHoi = cauHoiDeThi.Split('|').Length;

                // Tính điểm cho mỗi câu hỏi
                double diemMoiCau = 10.0 / tongSoCauHoi;

                // Tách chuỗi DapAnDaChon
                string[] dapAnDaChonArray = lsbailam[0].DapAnDaChon.Split('|');

                foreach (string dapAnDaChon in dapAnDaChonArray)
                {
                    // Loại bỏ dấu ngoặc vuông và tách chuỗi để lấy mã câu hỏi và đáp án đã chọn
                    string[] parts = dapAnDaChon.Trim('[', ']').Split(',');
                    string maCauHoi = parts[0].Trim();
                    string dapAn = parts[1].Trim();

                    // Lấy câu hỏi từ cơ sở dữ liệu
                    List<CauHoi> cauHois = getBaiThiBUS.GetMaCauHoiBaiLamBUS(maCauHoi);

                    if (cauHois.Count > 0)
                    {
                        CauHoi cauHoi = cauHois[0];

                        // Kiểm tra xem câu trả lời đã chọn có đúng không
                        if (dapAn == cauHoi.DapAnDung)
                        {
                            // Tăng số câu đúng và điểm
                            soCauDung++;
                            diem += diemMoiCau;
                        }
                    }
                }

                // Cập nhật số câu đúng và điểm
                lbSoCauDung.Text = $"Số câu đúng: {soCauDung}/{tongSoCauHoi}";
                lbDiem.Text = $"Điểm: {Math.Round(diem, 2)}"; // Làm tròn điểm đến 2 chữ số thập phân
            }
            else
            {
                MessageBox.Show("Lỗi khi lấy nội dung đề thi");
            }
        }





        void LoadBtnCauHoi_TraCuu(List<BaiLam> lsbailam, string noiDungDeThi)
        {
            flpCauHoi.Controls.Clear();

            string[] cauHoiArrayDeThi = noiDungDeThi.Split('|');
            int sttCauHoi = 1;

            foreach (var cauHoiDeThi in cauHoiArrayDeThi)
            {
                string maCauHoiDeThi = cauHoiDeThi.Trim(); // Mã câu hỏi từ DeThi

                Button btnCauHoi = new Button();
                btnCauHoi.Text = $"Câu {sttCauHoi}";
                btnCauHoi.Tag = maCauHoiDeThi; // Mã câu hỏi sẽ là Tag của nút
                btnCauHoi.Click += btnCauHoi_Click;

                foreach (var baiLam in lsbailam)
                {
                    string[] cauHoiArrayBaiLam = baiLam.DapAnDaChon.Split('|');
                    foreach (var cauHoiBaiLam in cauHoiArrayBaiLam)
                    {
                        string[] parts = cauHoiBaiLam.Trim('[', ']').Split(',');

                        if (parts.Length == 2)
                        {
                            string maCauHoiBaiLam = parts[0].Trim(); 
                            string dapAnDaChon = parts[1].Trim(); 

                            if (maCauHoiBaiLam == maCauHoiDeThi)
                            {
                                List<CauHoi> cauHois = getBaiThiBUS.GetMaCauHoiBaiLamBUS(maCauHoiDeThi);

                                if (cauHois.Count > 0)
                                {
                                    CauHoi cauHoi = cauHois[0];

                                    if (dapAnDaChon == cauHoi.DapAnDung)
                                    {
                                        btnCauHoi.BackColor = Color.LightGreen; 
                                    }
                                    else if (dapAnDaChon != cauHoi.DapAnDung)
                                    {
                                        btnCauHoi.BackColor = Color.Red; 
                                    }
                                }
                                break; 
                            }
                        }
                    }
                }
                flpCauHoi.Controls.Add(btnCauHoi);
                sttCauHoi++;
            }
        }




        private void btnCauHoi_Click(object sender, EventArgs e)
        {
            Button btnCauHoi = (Button)sender;
            if (btnCauHoi != null)
            {
                string maCauHoi = btnCauHoi.Tag.ToString();
                List<CauHoi> cauHois = getBaiThiBUS.GetMaCauHoiBaiLamBUS(maCauHoi);

                if (cauHois.Count > 0)
                {
                    CauHoi cauHoi = cauHois[0];
                    lbCauHoi_TraCuu.Text = cauHoi.NoiDungCauHoi;
                    rbDapAn_A.Text = $"A. {cauHoi.DapAnA}";
                    rbDapAn_B.Text = $"B. {cauHoi.DapAnB}";
                    rbDapAn_C.Text = $"C. {cauHoi.DapAnC}";
                    rbDapAn_D.Text = $"D. {cauHoi.DapAnD}";

                    // Hiển thị đáp án đúng
                    lbDapAnDung.Text = $"Đáp án đúng: {cauHoi.DapAnDung}";

                    // Lấy đáp án đã chọn từ DapAnDaChon của BaiLam
                    string dapAnDaChon = GetSelectedAnswerFromBaiLam(maCauHoi);

                    // Đặt RadioButton tương ứng với đáp án đã chọn
                    if (dapAnDaChon == "A")
                        rbDapAn_A.Checked = true;
                    else if (dapAnDaChon == "B")
                        rbDapAn_B.Checked = true;
                    else if (dapAnDaChon == "C")
                        rbDapAn_C.Checked = true;
                    else if (dapAnDaChon == "D")
                        rbDapAn_D.Checked = true;
                    else
                    {
                        rbDapAn_A.Checked = false;
                        rbDapAn_B.Checked = false;
                        rbDapAn_C.Checked = false;
                        rbDapAn_D.Checked = false;
                    }
                }
            }
        }


        // Hàm kiểm tra và trả về đáp án đã chọn từ DapAnDaChon của BaiLam
        private string GetSelectedAnswerFromBaiLam(string maCauHoi)
        {
            string maHS = Session.Instance.MaTK;
            string maBaiThi = cbBaiThi_TraCuu.SelectedValue.ToString();
            List<BaiLam> lsbailam = thongTinThiCuBUS.getBaiLam(maHS, maBaiThi);

            if (lsbailam.Count > 0)
            {
                string[] cauHoiArrayBaiLam = lsbailam[0].DapAnDaChon.Split('|');
                foreach (var cauHoiBaiLam in cauHoiArrayBaiLam)
                {
                    string[] parts = cauHoiBaiLam.Trim('[', ']').Split(',');

                    if (parts.Length == 2)
                    {
                        string maCauHoiBaiLam = parts[0].Trim();
                        string dapAnDaChon = parts[1].Trim();

                        // Kiểm tra xem câu hỏi này có trong BaiLam.DapAnDaChon hay không
                        if (maCauHoiBaiLam == maCauHoi)
                        {
                            return dapAnDaChon;
                        }
                    }
                }
            }

            return null;
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
