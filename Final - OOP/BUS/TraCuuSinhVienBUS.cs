using Final___OOP.DAO.Model;
using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    public class TraCuuSinhVienBUS
    {
        private TraCuuSinhVienDAO traCuuSVDAO;
        public TraCuuSinhVienBUS()
        {
            traCuuSVDAO = new TraCuuSinhVienDAO();
        }

        public List<TraCuuSinhVien> GetAllTraCuuSinhVien(string maLopHoc, string maMH, string maDeThi, string maSV)
        {
            return traCuuSVDAO.LayDanhSachTraCuuDAO(maLopHoc, maMH, maDeThi, maSV);
        }

        public void Dispose()
        {
            if (traCuuSVDAO != null) { traCuuSVDAO.Dispose(); }
        }
    }
}
