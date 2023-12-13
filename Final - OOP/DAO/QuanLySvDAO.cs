using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    internal class QuanLySvDAO
    {
        private ThiTracNghiemEntities db;

        public QuanLySvDAO()
        {
            db = new ThiTracNghiemEntities();
        }

        public void AddSinhVien(ThongTinSV sinhVien)
        {
            db.ThongTinSV.Add(sinhVien);
            db.SaveChanges();
        }
    }
}
