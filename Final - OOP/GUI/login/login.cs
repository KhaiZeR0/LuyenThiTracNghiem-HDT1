using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Final___OOP.winform
{
    public partial class Login : Form
    {
        private DangNhapBUS dangnhapBUS;
        public Login()
        {
            InitializeComponent();
            dangnhapBUS = new DangNhapBUS();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string maTK = txtemail.Text;
                string matKhau = txtpass.Text;

                if (dangnhapBUS.KiemTraDangNhap(maTK, matKhau))
                {
                    dangnhapBUS.KiemTraLoaiTaiKhoan(maTK);
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công");
                }
            }
            catch (Exception ex) {}
        }


        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fforgotpass fforgotpass = new Fforgotpass();
            fforgotpass.ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dangnhapBUS != null)
                dangnhapBUS.Dispose();
        }
    }
}
