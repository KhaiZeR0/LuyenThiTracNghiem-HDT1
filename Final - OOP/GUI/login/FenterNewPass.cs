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
    public partial class FenterNewPass : Form
    {
        public static string EmailGO { get; set; }
        private readonly ResetPassBUS resetPassBUS;
        public FenterNewPass()
        {
            InitializeComponent();
            resetPassBUS = new ResetPassBUS();
        }

        private void btnsavepass_Click(object sender, EventArgs e)
        {
            string matKhau = tbnewpass.Text;
            string xacNhanMatKhau = tbconfirmpass.Text;
            string email = EmailGO;

            if (resetPassBUS.KiemTraMatKhauHopLe(matKhau, xacNhanMatKhau))
            {
                resetPassBUS.CapNhatMatKhau(email, matKhau);
                MessageBox.Show("Mật khẩu đã được cập nhật.", "Thông báo!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp!");
            }
        }
    }
}
