using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP
{
    class DangNhapBUS
    {
        private DangNhapDAO dangnhapDAO;

        public DangNhapBUS()
        {
            dangnhapDAO = new DangNhapDAO();
        }

        public bool KiemTraDangNhap(string email, string matKhau)
        {
            return dangnhapDAO.LayThongTinDangNhap(email, matKhau);
        }

        public bool KiemTraLoaiTaiKhoan(string email)
        {
            int loaiTK = dangnhapDAO.LayLoaiTaiKhoan(email);

            if (loaiTK == 0) //admin
            {
                menuAdmin fAdmin = new menuAdmin();
                fAdmin.ShowDialog();
                return true;
            }
            else if (loaiTK == 1) //teacher
            {
                MenuTeacher menuTeacher = new MenuTeacher();
                menuTeacher.ShowDialog();
                return true;
            }
            else // student
            {
                MenuStudent menuStudent = new MenuStudent();
                menuStudent.ShowDialog();
                return false;
            }
        }
    }
}
