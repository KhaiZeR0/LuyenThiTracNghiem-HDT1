using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Final___OOP.BUS.SinhVienBUS;

namespace Final___OOP.DAO
{
    internal class SinhVienDAO
    {
        private ThiTracNghiemModelEntities db;

        public SinhVienDAO()
        {
            db = new ThiTracNghiemModelEntities();
        }

        public void AddSinhVienDAO(string maSV, string hoTenSV, DateTime ngaySinhSV, string diaChi, bool gioiTinh)
        {

            var newSinhVien = new ThongTinSV
            {
                MaSV = maSV,
                HoTen = hoTenSV,
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinhSV,
                DiaChi = diaChi,
            };
            db.ThongTinSVs.Add(newSinhVien);
            db.SaveChanges();
        }
        public void AddAccountvSVDAO(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {
            var newTaiKhoan = new TaiKhoan
            {
                MaTK = maSV,
                MatKhau = maSV,
                Email = email,
                LoaiTK = "2"
            };

            db.TaiKhoans.Add(newTaiKhoan);
            db.SaveChanges();

            AddSinhVienDAO(maSV,hoTenSV,ngaySinhSV,diaChi,gioiTinh);
            DSLopSVDAO(maSV, maLop);
        }
        public void DSLopSVDAO(string maHS, string maLop)
        {
            var newDSLop = new DanhSachLop
            {
                MaSV = maHS,
                MaLop = maLop,
                Temp = null
            };
            db.DanhSachLops.Add(newDSLop);
            db.SaveChanges();
        }
        public void UpdateSinhVienDAO(string maSV, string hoTen, DateTime ngaySinh, string maLop, string diaChi, string email, bool gioiTinh)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var svToUpdate = db.ThongTinSVs.Find(maSV);

                    if (svToUpdate != null)
                    {
                        svToUpdate.HoTen = hoTen;
                        svToUpdate.NgaySinh = ngaySinh;
                        svToUpdate.DiaChi = diaChi;
                        svToUpdate.GioiTinh = gioiTinh;

                        var lopHoc = db.DanhSachLops.SingleOrDefault(l => l.MaSV == maSV);
                        if (lopHoc != null)
                        {
                            lopHoc.MaLop = maLop;
                            db.Entry(lopHoc).State = EntityState.Modified; // Đánh dấu là đối tượng này đã bị thay đổi
                        }

                        var taiKhoan = db.TaiKhoans.SingleOrDefault(tk => tk.MaTK == maSV);
                        if (taiKhoan != null)
                        {
                            taiKhoan.Email = email;
                            db.Entry(taiKhoan).State = EntityState.Modified; // Đánh dấu là đối tượng này đã bị thay đổi
                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật sinh viên: " + ex.Message);
                    transaction.Rollback();
                }
            }
        }

        public void DeleteSinhVienDAO(string maSV)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var svToDelete = db.ThongTinSVs.Find(maSV);

                    if (svToDelete != null)
                    {
                        var lopHoc = db.DanhSachLops.SingleOrDefault(l => l.MaSV == maSV);
                        var taiKhoan = db.TaiKhoans.SingleOrDefault(tk => tk.MaTK == maSV);

                        if (lopHoc != null)
                        {
                            db.DanhSachLops.Remove(lopHoc);
                        }

                        if (taiKhoan != null)
                        {
                            db.TaiKhoans.Remove(taiKhoan);
                        }

                        db.ThongTinSVs.Remove(svToDelete);
                        db.SaveChanges();

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa sinh viên: " + ex.Message);
                    transaction.Rollback();
                }
            }
        }

        public List<SinhVienViewModel> LayDanhSachSinhVienDAO()
        {
            var query = from sv in db.ThongTinSVs
                        join ds in db.DanhSachLops on sv.MaSV equals ds.MaSV into svds
                        from ds in svds.DefaultIfEmpty()
                        join tk in db.TaiKhoans on sv.MaSV equals tk.MaTK into svtks
                        from tk in svtks.DefaultIfEmpty()
                        join lop in db.Lophocs on ds.MaLop equals lop.MaLop into dslophoc
                        from lop in dslophoc.DefaultIfEmpty()
                        select new SinhVienViewModel
                        {
                            MaSV = sv.MaSV,
                            HoTen = sv.HoTen,
                            GioiTinh = sv.GioiTinh,
                            NgaySinh = sv.NgaySinh,
                            DiaChi = sv.DiaChi,
                            Email = tk != null ? tk.Email : null,
                            MaLop = ds != null ? ds.MaLop : null,
                            TenLop = lop != null ? lop.TenLop : null,
                        };


            return query.ToList();
        }

    }
}
