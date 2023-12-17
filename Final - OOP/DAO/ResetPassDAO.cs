using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System.Linq;

namespace Final___OOP
{
    public class ResetPassDAO : ThiTracNghiemDAO
    {
        public void UpdateMatKhau(string email, string newMatKhau)
        {
            var taiKhoan = GetTaiKhoanByEmail(email);

            if (taiKhoan != null)
            {
                taiKhoan.MatKhau = newMatKhau;
                DbContext.SaveChanges();
            }
        }

        private TaiKhoan GetTaiKhoanByEmail(string email)
        {
            return DbContext.TaiKhoans.FirstOrDefault(tk => tk.Email == email);
        }
    }
}
