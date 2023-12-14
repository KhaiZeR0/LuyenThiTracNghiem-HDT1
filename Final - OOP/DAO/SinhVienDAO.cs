using System;
using System.Collections.Generic;
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
        public void UpdateSinhVienDAO(string maSV, string hoTenSV, DateTime ngaySinhSV, string diaChi, string email, bool gioiTinh)
        {
            var sinhVien = db.ThongTinSVs.Find(maSV);
            if (sinhVien != null)
            {
                //sinhVien.HoTenSV = hoTenSV;
                sinhVien.NgaySinh = ngaySinhSV;
                sinhVien.DiaChi = diaChi;
                sinhVien.GioiTinh = gioiTinh;

                db.SaveChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy sinh viên có mã " + maSV);
            }
        }
        public void DeleteSinhVienDAO(string maSV)
        {

            var sinhVien = db.ThongTinSVs.Find(maSV);
            if (sinhVien != null)
            {
                db.ThongTinSVs.Remove(sinhVien);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy sinh viên có mã " + maSV);
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
                            // ... thêm các thuộc tính khác nếu cần
                        };


            return query.ToList();
        }

    }
}
