using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System.Linq;

namespace Final___OOP
{
    class DangNhapDAO : ThiTracNghiemDAO
    {
        public bool LayThongTinDangNhap(string email, string matKhau)
        {
            return DbContext.TaiKhoans.Any(r => r.Email == email && r.MatKhau == matKhau);
        }

        public int LayLoaiTaiKhoan(string email)
        {
            TaiKhoan taiKhoan = DbContext.TaiKhoans.FirstOrDefault(r => r.Email == email);

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
