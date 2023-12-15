using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP
{
    class ResetPassDAO
    {
        private readonly ThiTracNghiemModelEntities context;
        public ResetPassDAO()
        {
            context = new ThiTracNghiemModelEntities();
        }

        public void UpdateMatKhau(string email, string newMatKhau)
        {
            var taiKhoan = GetTaiKhoanByEmail(email);

            if (taiKhoan != null)
            {
                taiKhoan.MatKhau = newMatKhau;
                context.SaveChanges();
            }
        }

        private TaiKhoan GetTaiKhoanByEmail(string email)
        {
            return context.TaiKhoans.FirstOrDefault(tk => tk.Email == email);
        }
    }
}
