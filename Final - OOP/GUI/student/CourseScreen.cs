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
using static Final___OOP.DAO.BaiThiDAO;

namespace Final___OOP
{
    public partial class CourseScreen : Form
    {
        private BaiThiInfoDTO baiThiInfo;  // Thêm biến để lưu đối tượng bài thi
        private BaiThiBUS baiThiBUS;
        private DateTime startTime; // Thời điểm bắt đầu làm bài
        private Timer timer;
        private List<string> selectedAnswers;


        public CourseScreen(BaiThiInfoDTO baiThiInfo)
        {
            InitializeComponent();

            this.baiThiInfo = baiThiInfo;
            this.startTime = DateTime.Now; // Ghi nhận thời điểm bắt đầu làm bài
            baiThiBUS = new BaiThiBUS();
            selectedAnswers = new List<string>(new string[baiThiInfo.SoLuongCau]);

            HienThiNutCauHoi();


            // Khởi tạo và cấu hình Timer
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timeThoiGianLamBai_Tick;
            timer.Start();
        }
        private void btnNopBai_Click(object sender, EventArgs e)
        {
            string maHS = Session.Instance.MaTK;
            string maBaiLam = baiThiInfo.MaDeThi;
            string BaiLam = string.Join("|", selectedAnswers);
            int trangThai = 1;
        }

        private void HienThiNutCauHoi()
        {
            flpCauHoi.Controls.Clear();

            string[] cauHoiArray = baiThiInfo.MaCauHoi.Split('|');

            for (int i = 0; i < cauHoiArray.Length; i++)
            {
                var cauHoi = cauHoiArray[i];

                Button btnCauHoi = new Button();
                btnCauHoi.Text = $"Câu {i + 1}";
                btnCauHoi.Tag = cauHoi;
                btnCauHoi.Click += btnCauHoi_Click;

                flpCauHoi.Controls.Add(btnCauHoi);
            }
        }

        private void btnCauHoi_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string selectQuestion = clickedButton.Tag.ToString();

                // Sử dụng đối tượng baiThiBUS để lấy thông tin chi tiết về câu hỏi
                List<CauHoi> cauHois = baiThiBUS.GetMaCauHoiBaiLamBUS(selectQuestion);

                if (cauHois.Count > 0)
                {
                    lbNoiDungCauHoi.Text = cauHois[0].NoiDungCauHoi;
                    rbDapAn_A.Text = $"A. {cauHois[0].DapAnA}";
                    rbDapAn_B.Text = $"B. {cauHois[0].DapAnB}";
                    rbDapAn_C.Text = $"C. {cauHois[0].DapAnC}";
                    rbDapAn_D.Text = $"D. {cauHois[0].DapAnD}";
                }
            }
        }


        private void timeThoiGianLamBai_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = baiThiInfo.TGLamBai - (DateTime.Now - startTime);

            // Hiển thị thời gian còn lại dưới dạng mm:ss
            string formattedTime = $"{(int)remainingTime.TotalMinutes:D2}:{remainingTime.Seconds:D2}";
            lbThoiGianLamBai.Text = $"Thời gian còn lại: {formattedTime}";

            // Kiểm tra nếu thời gian làm bài còn lại hết
            if (remainingTime <= TimeSpan.Zero)
            {
                timer.Stop(); // Dừng Timer khi thời gian làm bài hết
                lbThoiGianLamBai.Text = "Hết thời gian làm bài";
            }
        }

        private void rbDapAn_A_Click(object sender, EventArgs e)
        {
            UpdateSelectedAnswer(sender, "A");
        }

        private void rbDapAn_B_Click(object sender, EventArgs e)
        {
            UpdateSelectedAnswer(sender, "B");
        }

        private void rbDapAn_C_Click(object sender, EventArgs e)
        {
            UpdateSelectedAnswer(sender, "C");
        }

        private void rbDapAn_D_Click(object sender, EventArgs e)
        {
            UpdateSelectedAnswer(sender, "D");
        }

        private void UpdateSelectedAnswer(object sender, string answer)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                int questionIndex = int.Parse(clickedRadioButton.Name.Substring(12)) - 1; 
                selectedAnswers[questionIndex] = answer;
            }
        }

        private void CourseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}