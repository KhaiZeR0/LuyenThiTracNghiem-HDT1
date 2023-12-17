using Final___OOP.BUS;
using System;
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

        private void FenterNewPass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(resetPassBUS != null)
                resetPassBUS.Dispose();
        }
    }
}
