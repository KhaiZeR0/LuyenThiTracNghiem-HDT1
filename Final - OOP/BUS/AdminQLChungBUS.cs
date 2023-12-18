using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using static Final___OOP.AdminQLChungDAO;

namespace Final___OOP
{
    public class AdminQLChungBUS : IDisposable
    {
        private AdminQLChungDAO adminQLChungDAO;

        public AdminQLChungBUS()
        {
            adminQLChungDAO = new AdminQLChungDAO();
        }
        public void Dispose()
        {
            if (adminQLChungDAO != null) { adminQLChungDAO.Dispose(); }
        }

        //Môn học:
        public void AddMonHocBUS(string maMon, string tenMon)
        {
            adminQLChungDAO.AddMonHocDAO(maMon, tenMon);
        }

        public void UpdateMonHocBUS(string maMon, string tenMon)
        {
            adminQLChungDAO.UpdateMonHocDAO(maMon, tenMon);
        }

        public void DeleteMonHocBUS(string maMon)
        {
            adminQLChungDAO.DeleteMonHocDAO(maMon);
        }

        public class MonHocViewModel
        {
            public string MaMH { get; set; }
            public string TenMH { get; set; }
            public MonHocViewModel() { }
        }
        public List<MonHocViewModel> LayDanhSachMonHocBUS()
        {
            return adminQLChungDAO.LayDanhSachMonHocDAO();
        }

        //CHương:
        public class ChuongViewModel
        {
            public string MaChuong { get; set; }
            public string TenChuong { get; set; }
            public string MaMonHoc { get; set; }

            public ChuongViewModel() { }
        }

        public void AddChuongBUS(string maChuong, string tenChuong, string maMonHoc)
        {
            adminQLChungDAO.AddChuongDAO(maChuong, tenChuong, maMonHoc);
        }

        public void UpdateChuongBUS(string maChuong, string tenChuong, string maMonHoc)
        {
            adminQLChungDAO.UpdateChuongDAO(maChuong, tenChuong, maMonHoc);
        }

        public void DeleteChuongBUS(string maChuong)
        {
            adminQLChungDAO.DeleteChuongDAO(maChuong);
        }

        public List<ChuongViewModel> LayDanhSachChuongBUS()
        {
            return adminQLChungDAO.LayDanhSachChuongDAO();
        }

        //Lớp Học:
        public void AddLopHocBUS(string maLop, string tenLop)
        {
            adminQLChungDAO.AddLopHocDAO(maLop, tenLop);
        }

        public void UpdateLopHocBUS(string maLop, string tenLop)
        {
            adminQLChungDAO.UpdateLopHocDAO(maLop, tenLop);
        }

        public void DeleteLopHocBUS(string maLop)
        {
            adminQLChungDAO.DeleteLopHocDAO(maLop);
        }
        public class LopHocViewModel
        {
            public string MaLop { get; set; }
            public string TenLop { get; set; }
            public LopHocViewModel() { }
        }
        public List<LopHocViewModel> LayDanhSachLopHocBUS()
        {
            return adminQLChungDAO.LayDanhSachLopHocDAO();
        }
    }
}
