using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class GiangVienBUS
    {
        private SinhVienBUS IsValid = new SinhVienBUS();
        private GiangVienDAO giangVienDAO;
        public GiangVienBUS()
        {
            giangVienDAO = new GiangVienDAO();
        }

        public void AddGiangVienBUS(string maGV, string hoTenGV, DateTime ngaySinhGV, string diaChi, string email, bool gioiTinh)
        {
            giangVienDAO.AddGiangVienDAO(maGV, hoTenGV, ngaySinhGV, diaChi, email, gioiTinh);
        }

        public void UpdateGiangVienBUS(string maGV, string hoTenGV, DateTime ngaySinhGV, string diaChi, string email, bool gioiTinh)
        {
            giangVienDAO.UpdateGiangVienDAO(maGV, hoTenGV, ngaySinhGV, diaChi, email, gioiTinh);
        }
        public bool IsValidGiangVienBUS(string maSV, string hoTenSV, DateTime ngaySinhSV, string diaChi, string email, bool gioiTinh)
        {
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(hoTenSV) || string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            if (ngaySinhSV.AddYears(22) > DateTime.Now)
            {
                return false;
            }

            if (!IsValid.IsValidEmail(email))
            {
                return false;
            }

            return true;
        }
        
        public List<GiangVienView> GetGiangVienList()
        {
            return giangVienDAO.GetGiangVienViews();
        }
    }
}
