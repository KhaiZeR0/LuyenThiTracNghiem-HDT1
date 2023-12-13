using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___OOP.DAO
{
    internal class QuanLySvDAO
    {
        private ThiTracNghiemEntities db;

        public QuanLySvDAO()
        {
            db = new ThiTracNghiemEntities();
        }

        public void AddSinhVien(string maSV, string hoTenSV, DateTime ngaySinhSV, string maLop, string diaChi, string email, bool gioiTinh)
        {
            
            var newSinhVien = new ThongTinSV
            {
                MaSV = maSV,
                GioiTinh = true, 
                NgaySinh = ngaySinhSV,
                DiaChi = diaChi,
            };

            var newTaiKhoan = new TaiKhoan
            {
                MaTK = maSV,
                MatKhau = maSV, 
                Email = email,
                LoaiTK = "1" 
            };

            db.ThongTinSV.Add(newSinhVien);
            db.TaiKhoan.Add(newTaiKhoan);
            db.SaveChanges();
        }
        public void UpdateSinhVien(string maSV, string hoTenSV, DateTime ngaySinhSV, string diaChi, string email, bool gioiTinh)
        {
            var sinhVien = db.ThongTinSV.Find(maSV);
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
        public void DeleteSinhVien(string maSV)
        {
            
                var sinhVien = db.ThongTinSV.Find(maSV);
                if (sinhVien != null)
                {
                    db.ThongTinSV.Remove(sinhVien);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy sinh viên có mã " + maSV);
                }
        }
    }
}
