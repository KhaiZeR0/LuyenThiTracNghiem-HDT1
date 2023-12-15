using Final___OOP.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final___OOP.DAO
{
    internal class GiangVienDAO
    {
        private ThiTracNghiemModelEntities db;
        private GiangVienView giangVienView;
        public GiangVienDAO() 
        {
            db = new ThiTracNghiemModelEntities();
            giangVienView = new GiangVienView();
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

        }

        public List<GiangVienView> GetGiangVienViews() 
        {
            var query = 1;
            return query;
        }
    }
}
