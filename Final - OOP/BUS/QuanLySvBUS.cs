using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    public class QuanLySvBUS
    {
        private QuanLySvDAO SinhVienDAO;
        public QuanLySvBUS() 
        {
            SinhVienDAO = new QuanLySvDAO();
        }
        public void AddSinhVien(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {
            SinhVienDAO.AddSinhVien(maSV, hoTenSV, ngaySinhSV, maLop, diaChi, email, gioiTinh);
        }
    }
}
