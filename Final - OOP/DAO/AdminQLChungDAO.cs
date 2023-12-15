using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP
{
    class AdminQLChungDAO
    {
        private ThiTracNghiemModelEntities db;

        public AdminQLChungDAO()
        {
            db = new ThiTracNghiemModelEntities();
        }

        public void AddMonHocDAO(string maMon, string tenMon)
        {
            var newMonHoc = new MonHoc
            {
                MaMH = maMon,
                TenMH = tenMon
            };
            db.MonHocs.Add(newMonHoc);
            db.SaveChanges();
        }

        public void UpdateMonHocDAO(string maMon, string tenMon)
        {
            var monHocToUpdate = db.MonHocs.Find(maMon);

            if (monHocToUpdate != null)
            {
                monHocToUpdate.TenMH = tenMon;
                db.SaveChanges();
            }
        }

        public void DeleteMonHocDAO(string maMon)
        {
            var monHocToDelete = db.MonHocs.Find(maMon);

            if (monHocToDelete != null)
            {
                db.MonHocs.Remove(monHocToDelete);
                db.SaveChanges();
            }
        }

        public List<MonHoc> LayDanhSachMonHocDAO()
        {
            return db.MonHocs.ToList();
        }
    }
}
