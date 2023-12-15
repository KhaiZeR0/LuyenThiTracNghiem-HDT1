using Final___OOP.BUS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final___OOP.DAO
{
    internal class GiangVienDAO
    {
        private ThiTracNghiemModelEntities db;
        public GiangVienDAO() 
        {
            db = new ThiTracNghiemModelEntities();
        }
        public void AddGiangVienDAO(string maGV, string hoTenGV, DateTime ngaySinhGV, string diaChi, string email, bool gioiTinh)
        {
            var newAccGV = new TaiKhoan
            {
                MaTK = maGV,
                MatKhau = maGV,
                Email = email,
                LoaiTK = "1",
            };
            var newThongTinGV = new ThongTinCB
            {
                MaCB = maGV,
                HoTen = hoTenGV,
                NgaySinh = ngaySinhGV,
                DiaChi = diaChi,
                GioiTinh = gioiTinh
            };
            db.TaiKhoans.Add(newAccGV);
            db.SaveChanges();
            db.ThongTinCBs.Add(newThongTinGV);
            db.SaveChanges();
        }
        public void UpdateGiangVienDAO(string maGV, string hoTenGV, DateTime ngaySinhGV, string diaChi, string email, bool gioiTinh)
        {
            try
            {
                var giangVienToUpdate = db.ThongTinCBs.Find(maGV);

                if (giangVienToUpdate != null)
                {
                    giangVienToUpdate.HoTen = hoTenGV;
                    giangVienToUpdate.NgaySinh = ngaySinhGV;
                    giangVienToUpdate.DiaChi = diaChi;
                    giangVienToUpdate.GioiTinh = gioiTinh;

                    // Cập nhật thông tin trong bảng TaiKhoan (nếu có)
                    var taiKhoan = db.TaiKhoans.SingleOrDefault(tk => tk.MaTK == maGV);
                    if (taiKhoan != null)
                    {
                        taiKhoan.Email = email;
                        db.Entry(taiKhoan).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy giảng viên có mã: " + maGV);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật giảng viên: " + ex.Message);
            }
        }

        public void DeleteGiangVienDAO(string maGV)
        {
            try
            {
                var giangVienToDelete = db.ThongTinCBs.Find(maGV);

                if (giangVienToDelete != null)
                {
                    db.ThongTinCBs.Remove(giangVienToDelete);

                    var taiKhoan = db.TaiKhoans.SingleOrDefault(tk => tk.MaTK == maGV);
                    if (taiKhoan != null)
                    {
                        db.TaiKhoans.Remove(taiKhoan);
                    }

                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy giảng viên có mã: " + maGV);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa giảng viên: " + ex.Message);
            }
        }

        public List<GiangVienView> GetGiangVienViews()
        {
            var query = from gv in db.ThongTinCBs
                        join tk in db.TaiKhoans on gv.MaCB equals tk.MaTK
                        select new GiangVienView
                        {
                            MaGV = gv.MaCB,
                            HoTen = gv.HoTen,
                            NgaySinh = gv.NgaySinh,
                            DiaChi = gv.DiaChi,
                            Email = tk.Email,
                            GioiTinh = gv.GioiTinh
                        };

            return query.ToList();
        }

    }
}
