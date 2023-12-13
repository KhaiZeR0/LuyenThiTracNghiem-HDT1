using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace Final___OOP.DAO
{
    public class TaiKhoanDAO
    {
        private ThiTracNghiemEntities dbcontext;

        public TaiKhoanDAO()
        {
            dbcontext = new ThiTracNghiemEntities();
        }

        public bool LayThongTinDangNhap(string email, string matKhau)
        {
            return dbcontext.TaiKhoan.Any(r => r.Email == email && r.MatKhau == matKhau);
        }

        public int LayLoaiTaiKhoan(string email)
        {
            TaiKhoan taiKhoan = dbcontext.TaiKhoan.FirstOrDefault(r => r.Email == email);

            if (taiKhoan != null)
            {
                return int.Parse(taiKhoan.LoaiTK);
            }
            else
            {
                return 0;
            }
        }
    }
}