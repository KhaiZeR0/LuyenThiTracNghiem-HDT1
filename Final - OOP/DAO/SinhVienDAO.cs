using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Final___OOP.DAO
{
    internal class SinhVienDAO : ThiTracNghiemDAO
    {
        private SinhVienView sinhVienView;
        public SinhVienDAO()
        {
            sinhVienView = new SinhVienView();
        }

        private string GetSha256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
            public void AddSinhVienDAO(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {
            var hashedPassword = GetSha256Hash(maSV);
            var newTaiKhoan = new TaiKhoan
            {
                MaTK = maSV,
                MatKhau = hashedPassword,
                Email = email,
                LoaiTK = "2"
            };
            var newSinhVien = new ThongTinSV
            {
                MaSV = maSV,
                HoTen = hoTenSV,
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinhSV,
                DiaChi = diaChi,
            };
            var newDSLop = new DanhSachLop
            {
                MaSV = maSV,
                MaLop = maLop,
                Temp = null
            };
            
            DbContext.TaiKhoans.Add(newTaiKhoan);
            DbContext.SaveChanges();
            DbContext.ThongTinSVs.Add(newSinhVien);
            DbContext.SaveChanges();
            DbContext.DanhSachLops.Add(newDSLop);
            DbContext.SaveChanges();
        }
        public void UpdateSinhVienDAO(string maSV, string hoTen, DateTime ngaySinh, string maLop, string diaChi, string email, bool gioiTinh)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    var svToUpdate = DbContext.ThongTinSVs.Find(maSV);

                    if (svToUpdate != null)
                    {
                        svToUpdate.HoTen = hoTen;
                        svToUpdate.NgaySinh = ngaySinh;
                        svToUpdate.DiaChi = diaChi;
                        svToUpdate.GioiTinh = gioiTinh;

                        var lopHoc = DbContext.DanhSachLops.SingleOrDefault(l => l.MaSV == maSV);
                        if (lopHoc != null)
                        {
                            lopHoc.MaLop = maLop;
                            DbContext.Entry(lopHoc).State = EntityState.Modified; // Đánh dấu là đối tượng này đã bị thay đổi
                        }

                        var taiKhoan = DbContext.TaiKhoans.SingleOrDefault(tk => tk.MaTK == maSV);
                        if (taiKhoan != null)
                        {
                            taiKhoan.Email = email;
                            DbContext.Entry(taiKhoan).State = EntityState.Modified; // Đánh dấu là đối tượng này đã bị thay đổi
                        }

                        DbContext.SaveChanges();
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
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    var svToDelete = DbContext.ThongTinSVs.Find(maSV);

                    if (svToDelete != null)
                    {
                        var lopHoc = DbContext.DanhSachLops.SingleOrDefault(l => l.MaSV == maSV);
                        var taiKhoan = DbContext.TaiKhoans.SingleOrDefault(tk => tk.MaTK == maSV);

                        if (lopHoc != null)
                        {
                            DbContext.DanhSachLops.Remove(lopHoc);
                        }

                        if (taiKhoan != null)
                        {
                            DbContext.TaiKhoans.Remove(taiKhoan);
                        }

                        DbContext.ThongTinSVs.Remove(svToDelete);
                        DbContext.SaveChanges();

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

        public List<SinhVienView> LayDanhSachSinhVienDAO()
        {
            var query = from sv in DbContext.ThongTinSVs
                        join ds in DbContext.DanhSachLops on sv.MaSV equals ds.MaSV into svds
                        from ds in svds.DefaultIfEmpty()
                        join tk in DbContext.TaiKhoans on sv.MaSV equals tk.MaTK into svtks
                        from tk in svtks.DefaultIfEmpty()
                        join lop in DbContext.LopHocs on ds.MaLop equals lop.MaLop into dslophoc
                        from lop in dslophoc.DefaultIfEmpty()
                        select new SinhVienView
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
        public bool IsDuplicateEmailDAO(string email)
        {
            return DbContext.TaiKhoans.Any(tk => tk.Email == email);
        }

    }
}
