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
        private DangNhapBUS dangnhapBUS;
        public login()
        {
            InitializeComponent();
            dangnhapBUS = new DangNhapBUS();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtemail.Text;
                string matKhau = txtpass.Text;

                if (dangnhapBUS.KiemTraDangNhap(email, matKhau))
                {
                    if (dangnhapBUS.KiemTraLoaiTaiKhoan(email))
                    {
                        MessageBox.Show("oke");
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

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fforgotpass fforgotpass = new Fforgotpass();
            fforgotpass.ShowDialog();
        }
    }
}
