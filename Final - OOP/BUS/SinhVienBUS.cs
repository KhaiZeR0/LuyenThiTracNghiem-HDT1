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
    }
}
