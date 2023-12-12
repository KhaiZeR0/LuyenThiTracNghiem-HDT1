using Final___OOP.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___OOP.winform
{
    public partial class login : Form
    {
        private TaiKhoanBUS taiKhoanBUS;

        public login()
        {
            InitializeComponent();
            taiKhoanBUS = new TaiKhoanBUS();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtemail.Text;
                string matKhau = txtpass.Text;

                if (taiKhoanBUS.KiemTraDangNhap(email, matKhau))
                {
                    if (taiKhoanBUS.KiemTraLoaiTaiKhoan(email))
                    {
                        MessageBox.Show("Đăng nhập thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không giòn");
                    }
                }
                else
                {
                    MessageBox.Show("Không giòn");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void linkforgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotpass Fforgotpass = new forgotpass();
            Fforgotpass.ShowDialog();
        }
    }
}
