using Final___OOP.DAO;
using Final___OOP.winform.student;
using Final___OOP.winform.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___OOP.BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAO taiKhoanDAO;

        public TaiKhoanBUS()
        {
            taiKhoanDAO = new TaiKhoanDAO();
        }

        public bool KiemTraDangNhap(string email, string matKhau)
        {
            return taiKhoanDAO.LayThongTinDangNhap(email, matKhau);
        }

        public bool KiemTraLoaiTaiKhoan(string email)
        {
            int loaiTK = taiKhoanDAO.LayLoaiTaiKhoan(email);

            if (loaiTK == 0) //admin
            {
                menuAdmin fAdmin = new menuAdmin();
                fAdmin.ShowDialog();
                return true;
            }
            else if (loaiTK == 1) //teacher
            {
                menuTeacher fteacher = new menuTeacher();
                fteacher.ShowDialog();
                return true;
            }
            else // student
            {
                Menu_student fstudent = new Menu_student();
                fstudent.ShowDialog();
                return false;
            }
        }
    }
}
