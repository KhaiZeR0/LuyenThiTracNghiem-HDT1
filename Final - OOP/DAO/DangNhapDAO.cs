using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP
{
    class DangNhapDAO
    {
        private ThiTracNghiemEntities dbcontext;

        public DangNhapDAO()
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
