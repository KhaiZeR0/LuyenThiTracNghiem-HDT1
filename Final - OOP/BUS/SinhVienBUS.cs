using Final___OOP.DAO;
using System;
using System.Collections.Generic;

namespace Final___OOP.BUS
{
    public class SinhVienBUS : IDisposable
    {
        private SinhVienDAO sinhVienDAO;

        public SinhVienBUS() { sinhVienDAO = new SinhVienDAO(); }
        
        public void AddSinhVienBUS(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {
            sinhVienDAO.AddSinhVienDAO(maSV, hoTenSV, ngaySinhSV, maLop, diaChi, email, gioiTinh);
        }

        public void UpdateSinhVienBUS(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {
            sinhVienDAO.UpdateSinhVienDAO(maSV, hoTenSV, ngaySinhSV, maLop, diaChi, email, gioiTinh);
        }

        public void DeleteSinhVienBUS(string maSV)
        {
            sinhVienDAO.DeleteSinhVienDAO(maSV);
        }

        public bool IsValidSinhVienDataBUS(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
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
        

        public bool IsValidEmail(string email)
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
        public bool IsDuplicateEmail(string email)
        {
            return sinhVienDAO.IsDuplicateEmailDAO(email);
        }


        public List<SinhVienView> LayDanhSachSinhVien()
        {
            return sinhVienDAO.LayDanhSachSinhVienDAO();
        }

        public void Dispose()
        {
            if(sinhVienDAO != null) { sinhVienDAO.Dispose(); }
        }
    }

}
