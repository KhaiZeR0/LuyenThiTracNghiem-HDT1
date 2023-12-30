using Final___OOP.DAO.Model;
using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___OOP.BUS
{
    public class TraCuuSinhVienBUS:IDisposable
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
        public List<TraCuuSinhVien> GetDanhSachSinhVien(string maLopHoc, string maMH, string maDeThi, string maSV)
        {
            try
            {
                return traCuuSVDAO.LayDanhSachTraCuuDAO(maLopHoc, maMH, maDeThi, maSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message);
                return new List<TraCuuSinhVien>();
            }
        }
        public void Dispose()
        {
            if (traCuuSVDAO != null) { traCuuSVDAO.Dispose(); }
        }
    }
}
