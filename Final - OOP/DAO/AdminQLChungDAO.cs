using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using static Final___OOP.AdminQLChungBUS;

namespace Final___OOP
{
    class AdminQLChungDAO : ThiTracNghiemDAO
    {

        // Môn học:
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
        public List<MonHocViewModel> LayDanhSachMonHocDAO()
        {
            var query = from mh in DbContext.MonHocs
                        select new MonHocViewModel
                        {
                            MaMH = mh.MaMH,
                            TenMH = mh.TenMH,
                        };

            return query.ToList();
        }

        //Chương:
        public void AddChuongDAO(string maChuong, string tenChuong, string maMonHoc)
        {
            var newChuong = new Chuong
            {
                MaChuong = maChuong,
                TenChuong = tenChuong,
                MaMH = maMonHoc
            };
            DbContext.Chuongs.Add(newChuong);
            DbContext.SaveChanges();
        }

        public void UpdateChuongDAO(string maChuong, string tenChuong, string maMonHoc)
        {
            var chuongToUpdate = DbContext.Chuongs.Find(maChuong);

            if (chuongToUpdate != null)
            {
                chuongToUpdate.TenChuong = tenChuong;
                chuongToUpdate.MaMH = maMonHoc;
                DbContext.SaveChanges();
            }
        }

        public void DeleteChuongDAO(string maChuong)
        {
            var chuongToDelete = DbContext.Chuongs.Find(maChuong);

            if (chuongToDelete != null)
            {
                DbContext.Chuongs.Remove(chuongToDelete);
                DbContext.SaveChanges();
            }
        }

        public List<ChuongViewModel> LayDanhSachChuongDAO()
        {
            var query = from ch in DbContext.Chuongs
                        select new ChuongViewModel
                        {
                            MaChuong = ch.MaChuong,
                            TenChuong = ch.TenChuong,
                            MaMonHoc = ch.MaMH
                        };

            return query.ToList();
        }

        //Lớp học: (QLCHUNG)
        public void AddLopHocDAO(string maLop, string tenLop)
        {
            var newLopHoc = new LopHoc
            {
                MaLop = maLop,
                TenLop = tenLop
            };
            DbContext.LopHocs.Add(newLopHoc);
            DbContext.SaveChanges();
        }

        public void UpdateLopHocDAO(string maLop, string tenLop)
        {
            var lopHocToUpdate = DbContext.LopHocs.Find(maLop);

            if (lopHocToUpdate != null)
            {
                lopHocToUpdate.TenLop = tenLop;
                DbContext.SaveChanges();
            }
        }

        public void DeleteLopHocDAO(string maLop)
        {
            var lopHocToDelete = DbContext.LopHocs.Find(maLop);

            if (lopHocToDelete != null)
            {
                DbContext.LopHocs.Remove(lopHocToDelete);
                DbContext.SaveChanges();
            }
        }
        public List<LopHocViewModel> LayDanhSachLopHocDAO()
        {
            var query = from lh in DbContext.LopHocs
                        select new LopHocViewModel
                        {
                            MaLop = lh.MaLop,
                            TenLop = lh.TenLop,
                        };

            return query.ToList();
        }
    }
}
