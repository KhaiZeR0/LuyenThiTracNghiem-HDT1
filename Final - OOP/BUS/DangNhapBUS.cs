﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP
{
    public class DangNhapBUS : IDisposable
    {
        private DangNhapDAO dangnhapDAO;

        public DangNhapBUS()
        {
            dangnhapDAO = new DangNhapDAO();
        }

        public bool KiemTraDangNhap(string maTK, string matKhau)
        {
            bool result = dangnhapDAO.LayThongTinDangNhap(maTK, matKhau);

            if (result)
            {
                Session.Instance.SetMaTK(maTK);
            }

            return result;
        }

        public bool KiemTraLoaiTaiKhoan(string maTK)
        {
            int loaiTK = dangnhapDAO.LayLoaiTaiKhoan(maTK);

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

        public void Dispose()
        {
            if (dangnhapDAO != null) {  dangnhapDAO.Dispose(); }
        }
    }
}
