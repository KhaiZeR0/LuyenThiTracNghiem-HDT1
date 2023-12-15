using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP
{
    class AdminQLChungBUS
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
    }
}
