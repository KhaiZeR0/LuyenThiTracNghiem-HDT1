using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System.Collections.Generic;
using System.Linq;

namespace Final___OOP
{
    class AdminQLChungDAO : ThiTracNghiemDAO
    {
        public void AddMonHocDAO(string maMon, string tenMon)
        {
            var newMonHoc = new MonHoc
            {
                MaMH = maMon,
                TenMH = tenMon
            };
            DbContext.MonHocs.Add(newMonHoc);
            DbContext.SaveChanges();
        }

        public void UpdateMonHocDAO(string maMon, string tenMon)
        {
            var monHocToUpdate = DbContext.MonHocs.Find(maMon);

            if (monHocToUpdate != null)
            {
                monHocToUpdate.TenMH = tenMon;
                DbContext.SaveChanges();
            }
        }

        public void DeleteMonHocDAO(string maMon)
        {
            var monHocToDelete = DbContext.MonHocs.Find(maMon);

            if (monHocToDelete != null)
            {
                DbContext.MonHocs.Remove(monHocToDelete);
                DbContext.SaveChanges();
            }
        }

        public List<MonHoc> LayDanhSachMonHocDAO()
        {
            return DbContext.MonHocs.ToList();
        }
    }
}
