using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Final___OOP.ResetPassBUS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final___OOP
{
    public partial class Fforgotpass : Form
    {
        string randomcode;
        public static string to;
        private readonly ResetPassBUS resetPassBUS;
        public Fforgotpass()
        {
            InitializeComponent();
            resetPassBUS = new ResetPassBUS();
        }

        private void btnotp_Click(object sender, EventArgs e)
        {
            // send code
            string from, pass, messagebody;
            Random rand = new Random();
            randomcode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (tbemail.Text).ToString();
            from = "khai.sendmail@gmail.com";
            pass = "bfsjnqexelavxnhi";
            messagebody = $"Mã của bạn là: {randomcode}";
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Mã lấy lại mật khẩu";

            // Lưu địa chỉ email vào biến to
            FenterNewPass.EmailGO = to;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Gửi mã thành công, vui lòng check hòm thư của bạn");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (randomcode == (tbconfirm.Text).ToString())
            {
                to = tbemail.Text;
                FenterNewPass fenterNewPass = new FenterNewPass();
                fenterNewPass.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai mã, vui lòng nhập lại.");
            }
        }
    }
}
