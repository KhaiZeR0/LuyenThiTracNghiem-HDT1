using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class SinhVienBUS
    {
        private SinhVienDAO sinhVienDAO;

        public SinhVienBUS() { sinhVienDAO = new SinhVienDAO(); }
        
        public void AddSinhVienBUS(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {
            sinhVienDAO.AddAccountvSVDAO(maSV, hoTenSV, ngaySinhSV, maLop, diaChi, email, gioiTinh);
        }
        
        public bool IsValidSinhVienData(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {

            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(hoTenSV) || string.IsNullOrWhiteSpace(maLop) ||string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            if (ngaySinhSV.AddYears(18) > DateTime.Now)
            {
                return false;
            }

            if (!IsValidEmail(email))
            {
                return false;
            }

            return true;
        }
        public void UpdateSinhVienBUS(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {
            sinhVienDAO.UpdateSinhVienDAO(maSV, hoTenSV, ngaySinhSV, maLop, diaChi, email, gioiTinh);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        internal class SinhVienViewModel
        {
            public string MaSV { get; set; }
            public string HoTen { get; set; }
            public bool GioiTinh { get; set; }
            public DateTime NgaySinh { get; set; }
            public string DiaChi { get; set; }
            public string Email { get; set; }
            public string MaLop { get; set; }
            public string TenLop { get; set; }

            public SinhVienViewModel() { }
        }
        public List<SinhVienViewModel> LayDanhSachSinhVien()
        {
            return sinhVienDAO.LayDanhSachSinhVienDAO();
        }
    }

}
