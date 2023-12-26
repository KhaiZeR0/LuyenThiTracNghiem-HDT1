using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using Final___OOP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        private string selectQuestion;
        Dictionary<string, string> selectedAnswers = new Dictionary<string, string>();
        public CourseScreen(BaiThiInfoDTO baiThiInfo)
        {
            InitializeComponent();

            this.baiThiInfo = baiThiInfo;
            this.startTime = DateTime.Now; 
            baiThiBUS = new BaiThiBUS();
       

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
            bool trangThai = true;
            baiThiBUS.AddBaiThiBUS(maBaiLam, maHS, BaiLam, trangThai);
            this.Close();
        }

        private void HienThiNutCauHoi()
        {
            flpCauHoi.Controls.Clear();

            string[] cauHoiArray = baiThiInfo.MaCauHoi.Split('|');
            selectQuestion = cauHoiArray[0];
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
                 selectQuestion = clickedButton.Tag.ToString();
                List<CauHoi> cauHois = baiThiBUS.GetMaCauHoiBaiLamBUS(selectQuestion);

                if (cauHois.Count > 0)
                {                    
                    lbNoiDungCauHoi.Text = cauHois[0].NoiDungCauHoi;
                    rbDapAn_A.Text = $"A. {cauHois[0].DapAnA}";
                    rbDapAn_B.Text = $"B. {cauHois[0].DapAnB}";
                    rbDapAn_C.Text = $"C. {cauHois[0].DapAnC}";
                    rbDapAn_D.Text = $"D. {cauHois[0].DapAnD}";
                    if (selectedAnswers.ContainsKey(selectQuestion))
                    {
                        if(selectedAnswers[selectQuestion] == "A")
                            rbDapAn_A.Checked = true;
                        else if (selectedAnswers[selectQuestion] == "B")
                            rbDapAn_B.Checked = true;
                        else if (selectedAnswers[selectQuestion] == "C")
                            rbDapAn_C.Checked = true;
                        else if (selectedAnswers[selectQuestion] == "D")
                            rbDapAn_D.Checked = true;
                    }
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
        
        private void timeThoiGianLamBai_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = baiThiInfo.TGLamBai - (DateTime.Now - startTime);

            string formattedTime = $"{(int)remainingTime.TotalMinutes:D2}:{remainingTime.Seconds:D2}";
            lbThoiGianLamBai.Text = $"Thời gian còn lại: {formattedTime}";

            if (remainingTime <= TimeSpan.Zero)
            {
                timer.Stop(); 
                lbThoiGianLamBai.Text = "Hết thời gian làm bài";
                btnNopBai.PerformClick();
            }
        }

        

        private void UpdateSelectedAnswer(object sender, string answer)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                //int questionIndex = int.Parse(clickedRadioButton.Name.Substring(12)) - 1;
                selectedAnswers[selectQuestion] = answer;

            }
        }
        private void rbDapAn_A_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedAnswer(sender, "A");
        }

        private void rbDapAn_B_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedAnswer(sender, "B");
        }

        private void rbDapAn_C_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedAnswer(sender, "C");
        }

        private void rbDapAn_D_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedAnswer(sender, "D");
        }
        private void CourseScreen_Load(object sender, EventArgs e)
        {

        }
        private void CourseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}