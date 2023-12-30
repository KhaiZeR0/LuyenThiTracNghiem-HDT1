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
            private string maMH;
            private string tenMH;

            public string MaMH { get => maMH; set => maMH = value; }
            public string TenMH { get => tenMH; set => tenMH = value; }

            public MonHocViewModel() { }
        }
        public List<MonHocViewModel> LayDanhSachMonHocBUS()
        {
            return adminQLChungDAO.LayDanhSachMonHocDAO();
        }

        //CHương:
        public class ChuongViewModel
        {
            private string maChuong;
            private string tenChuong;
            private string maMonHoc;

            public string MaChuong { get => maChuong; set => maChuong = value; }
            public string TenChuong { get => tenChuong; set => tenChuong = value; }
            public string MaMonHoc { get => maMonHoc; set => maMonHoc = value; }

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
            private string maLop;
            private string tenLop;

            public string MaLop { get => maLop; set => maLop = value; }
            public string TenLop { get => tenLop; set => tenLop = value; }

            public LopHocViewModel() { }
        }
        public List<LopHocViewModel> LayDanhSachLopHocBUS()
        {
            return adminQLChungDAO.LayDanhSachLopHocDAO();
        }
    }
}
