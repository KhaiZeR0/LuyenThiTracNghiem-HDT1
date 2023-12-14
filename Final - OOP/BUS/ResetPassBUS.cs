using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Final___OOP
{
    class ResetPassBUS
    {
        public static bool VerifyCode(string inputCode, string generatedCode)
        {
            return inputCode == generatedCode;
        }
        public static bool SendEmail(string to, string randomCode)
        {
            try
            {
                string from = "khai.sendmail@gmail.com";
                string pass = "bfsjnqexelavxnhi";

                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = $"Mã của bạn là: {randomCode}";
                message.Subject = "Mã lấy lại mật khẩu";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, pass);

                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                return false;
            }
        }
    }
}
