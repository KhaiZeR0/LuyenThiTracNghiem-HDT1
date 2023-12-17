using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;

namespace Final___OOP
{
    public class AdminQLChungBUS : IDisposable
    {
        private AdminQLChungDAO adminQLChungDAO;

        public AdminQLChungBUS()
        {
            adminQLChungDAO = new AdminQLChungDAO();
        }

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

        public List<MonHoc> LayDanhSachMonHocBUS()
        {
            return adminQLChungDAO.LayDanhSachMonHocDAO();
        }

        public void Dispose()
        {
            if(adminQLChungDAO != null) {  adminQLChungDAO.Dispose(); }
        }
    }
}
