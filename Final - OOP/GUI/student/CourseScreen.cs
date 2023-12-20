using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using Final___OOP.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Final___OOP
{
    public partial class CourseScreen : Form
    {
        private BaiThiInfoDTO baiThiInfo;
        private BaiThiBUS baiThiBUS;
        private DateTime startTime;
        private Timer timer;
        private List<string> selectedAnswers;
        private int currentQuestionIndex = -1;

        public CourseScreen(BaiThiInfoDTO baiThiInfo)
        {
            InitializeComponent();

            this.baiThiInfo = baiThiInfo;
            this.startTime = DateTime.Now;
            baiThiBUS = new BaiThiBUS();
            selectedAnswers = new List<string>(new string[baiThiInfo.SoLuongCau]);

            HienThiNutCauHoi();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timeThoiGianLamBai_Tick;
            timer.Start();
        }

        private void btnNopBai_Click(object sender, EventArgs e)
        {

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

                // Xóa nút radio trước khi cập nhật chi tiết câu hỏi
                ClearRadioButtons();

                List<CauHoi> cauHois = baiThiBUS.GetMaCauHoiBaiLamBUS(selectQuestion);

                if (cauHois.Count > 0)
                {
                    lbNoiDungCauHoi.Text = cauHois[0].NoiDungCauHoi;
                    rbDapAn_A.Text = $"A. {cauHois[0].DapAnA}";
                    rbDapAn_B.Text = $"B. {cauHois[0].DapAnB}";
                    rbDapAn_C.Text = $"C. {cauHois[0].DapAnC}";
                    rbDapAn_D.Text = $"D. {cauHois[0].DapAnD}";

                    currentQuestionIndex = int.Parse(clickedButton.Text.Substring(4)) - 1;

                    // Kiểm tra nếu câu hỏi đã được chọn trước đó thì cập nhật radiobox
                    if (currentQuestionIndex >= 0 && currentQuestionIndex < selectedAnswers.Count)
                    {
                        string selectedAnswer = selectedAnswers[currentQuestionIndex];
                        if (!string.IsNullOrEmpty(selectedAnswer))
                        {
                            char selectedOption = selectedAnswer.Split(',')[1][0];
                            CheckRadioButton(selectedOption);
                        }
                        else
                        {
                            ClearRadioButtons();
                        }
                    }
                    else
                    {
                        // Nếu không có câu trả lời được chọn trước đó, kiểm tra xem có câu trả lời nào được chọn cho câu hỏi hiện tại không
                        string selectedAnswer = selectedAnswers[currentQuestionIndex];
                        if (!string.IsNullOrEmpty(selectedAnswer))
                        {
                            char selectedOption = selectedAnswer.Split(',')[1][0];
                            CheckRadioButton(selectedOption);
                        }
                    }
                }
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
                string name = clickedRadioButton.Name;

                int prefixLength = "rbDapAn_".Length;

                if (name.Length > prefixLength)
                {
                    string indexString = name.Substring(prefixLength);
                    int questionIndex;

                    if (int.TryParse(indexString, out questionIndex))
                    {
                        questionIndex--;

                        if (questionIndex >= 0 && questionIndex < selectedAnswers.Count)
                        {
                            string questionCode = baiThiInfo.MaCauHoi.Split('|')[questionIndex];
                            selectedAnswers[questionIndex] = $"{questionCode},{answer}";
                        }
                    }
                }
            }
        }
        private void ClearRadioButtons()
        {
            rbDapAn_A.Checked = false;
            rbDapAn_B.Checked = false;
            rbDapAn_C.Checked = false;
            rbDapAn_D.Checked = false;

            if (currentQuestionIndex >= 0 && currentQuestionIndex < selectedAnswers.Count)
            {
                selectedAnswers[currentQuestionIndex] = "";
            }
        }

        private void CheckRadioButton(char selectedOption)
        {
            switch (selectedOption)
            {
                case 'A':
                    rbDapAn_A.Checked = true;
                    break;
                case 'B':
                    rbDapAn_B.Checked = true;
                    break;
                case 'C':
                    rbDapAn_C.Checked = true;
                    break;
                case 'D':
                    rbDapAn_D.Checked = true;
                    break;
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
            }
        }
        private void CourseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Xử lý sự kiện khi form đóng
        }
    }
}
