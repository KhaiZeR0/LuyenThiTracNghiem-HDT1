using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Final___OOP
{
    class DangNhapDAO : ThiTracNghiemDAO
    {
        public bool LayThongTinDangNhap(string maTK, string matKhau)
        {
            string hashedPassword = GetSHA256Hash(matKhau);
            return DbContext.TaiKhoans.Any(r => r.MaTK == maTK && r.MatKhau == hashedPassword);
        }


        public int LayLoaiTaiKhoan(string maTK)
        {
            TaiKhoan taiKhoan = DbContext.TaiKhoans.FirstOrDefault(r => r.MaTK == maTK);

            if (taiKhoan != null)
            {
                return int.Parse(taiKhoan.LoaiTK);
            }
            else
            {
                return 0;
            }
        }
        private string GetSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
}
