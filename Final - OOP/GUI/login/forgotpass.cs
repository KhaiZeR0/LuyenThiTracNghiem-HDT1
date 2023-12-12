using Final___OOP.BUS;
using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Final___OOP.BUS.resetPassBUS;
using static Final___OOP.BUS.TaiKhoanBUS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final___OOP.winform
{
    public partial class forgotpass : Form
    {
        private string randomCode;
        public forgotpass()
        {
            InitializeComponent();
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            string inputCode = tbconfirm.Text;

            if (ResetPassBUS.VerifyCode(inputCode, randomCode))
            {
                MessageBox.Show("oke");
            }
            else
            {
                MessageBox.Show("Sai mã, vui lòng nhập lại.");
            }
        }

        private void btnotp_Click(object sender, EventArgs e)
        {
            // send code
            Random rand = new Random();
            randomCode = rand.Next(999999).ToString();

            string to = tbemail.Text;

            if (resetPassDAO.SendEmail(to, randomCode))
            {
                MessageBox.Show("Gửi mã thành công, vui lòng kiểm tra hòm thư của bạn.");
            }
            else
            {
                MessageBox.Show("Gửi mã thất bại. Vui lòng thử lại sau.");
            }
        }
    }
}
