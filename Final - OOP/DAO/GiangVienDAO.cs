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
    public class GiangVienDAO : ThiTracNghiemDAO
    {
        private GiangVienView giangVienView;
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
        public void AddGiangVienDAO(string maGV, string hoTenGV, DateTime ngaySinhGV, string diaChi, string email, bool gioiTinh)
        {
            if (IsDuplicateEmail(email, ""))
            {
                throw new Exception("Email đã tồn tại. Vui lòng chọn một email khác.");
            }

            var hashedPassword = GetSha256Hash(maGV);
            var newAccGV = new TaiKhoan
            {
                MaTK = maGV,
                MatKhau = hashedPassword,
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
            DbContext.TaiKhoans.Add(newAccGV);
            DbContext.SaveChanges();
            DbContext.ThongTinCBs.Add(newThongTinGV);
            DbContext.SaveChanges();
        }
        public void UpdateGiangVienDAO(string maGV, string hoTenGV, DateTime ngaySinhGV, string diaChi, string email, bool gioiTinh)
        {
            try
            {
                var giangVienToUpdate = DbContext.ThongTinCBs.Find(maGV);

                if (giangVienToUpdate != null)
                {
                    giangVienToUpdate.HoTen = hoTenGV;
                    giangVienToUpdate.NgaySinh = ngaySinhGV;
                    giangVienToUpdate.DiaChi = diaChi;
                    giangVienToUpdate.GioiTinh = gioiTinh;

                    // Cập nhật thông tin trong bảng TaiKhoan (nếu có)
                    var taiKhoan = DbContext.TaiKhoans.SingleOrDefault(tk => tk.MaTK == maGV);
                    if (taiKhoan != null)
                    {
                        taiKhoan.Email = email;
                        DbContext.Entry(taiKhoan).State = EntityState.Modified;
                    }

                    DbContext.SaveChanges();
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
                var giangVienToDelete = DbContext.ThongTinCBs.Find(maGV);

                if (giangVienToDelete != null)
                {
                    DbContext.ThongTinCBs.Remove(giangVienToDelete);

                    var taiKhoan = DbContext.TaiKhoans.SingleOrDefault(tk => tk.MaTK == maGV);
                    if (taiKhoan != null)
                    {
                        DbContext.TaiKhoans.Remove(taiKhoan);
                    }

                    DbContext.SaveChanges();
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
            var query = from gv in DbContext.ThongTinCBs
                        join tk in DbContext.TaiKhoans on gv.MaCB equals tk.MaTK
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
        public bool IsDuplicateEmail(string email, string maGV)
        {
            // Kiểm tra xem có giảng viên nào khác có cùng email không (trừ giảng viên đang cập nhật)
            var existingGiangVien = DbContext.ThongTinCBs
                .Where(gv => gv.MaCB != maGV && gv.TaiKhoan.Email == email)
                .FirstOrDefault();

            // Nếu tồn tại giảng viên khác có cùng email, trả về true
            return existingGiangVien != null;
        }
    }
}
