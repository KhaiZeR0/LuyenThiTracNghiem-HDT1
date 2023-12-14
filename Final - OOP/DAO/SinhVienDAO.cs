using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                GioiTinh = true,
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
    }
}
