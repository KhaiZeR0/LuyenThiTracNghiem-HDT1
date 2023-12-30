using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class QLDeThiBUS : IDisposable
    {
        private QLDeThiDAO QLDeThiDAO;
        public QLDeThiBUS()
        {
            QLDeThiDAO = new QLDeThiDAO();
        }
        public void ThemDeThiBUS(string maDeThi, string tenDeThi, TimeSpan thoiGianLamBai, string maMonHoc, string maLop, string maCauHoiString, int soLuong, string MaCB)
        {
            QLDeThiDAO.ThemDeThiDAO(maDeThi, tenDeThi, thoiGianLamBai, maMonHoc, maLop, maCauHoiString, soLuong, MaCB);
        }

        public List<CauHoi_View> GetCauHoiByChuongBUS(string maChuong)
        {
            return QLDeThiDAO.GetCauHoiByChuongDAO(maChuong);
        }
        public List<CauHoi_View> GetCauHoiBUS(string maCauHoi)
        {
            return QLDeThiDAO.GetCauHoiDAO(maCauHoi);
        }
        public void XoaDeThiBUS(string maDeThi)
        {
            QLDeThiDAO.XoaDeThiDAO(maDeThi);
        }
        public class DeThiViewModel
        {
            private string maDeThi;
            private string tenDeThi;
            private TimeSpan tGLamBai;
            private int soLuongCau;
            private string maCB;
            private string tenLop; 
            private string tenMH;

            public string MaDeThi { get => maDeThi; set => maDeThi = value; }
            public string TenDeThi { get => tenDeThi; set => tenDeThi = value; }
            public TimeSpan TGLamBai { get => tGLamBai; set => tGLamBai = value; }
            public int SoLuongCau { get => soLuongCau; set => soLuongCau = value; }
            public string MaCB { get => maCB; set => maCB = value; }
            public string TenLop { get => tenLop; set => tenLop = value; } 
            public string TenMH { get => tenMH; set => tenMH = value; } 

            public DeThiViewModel() { }
        }

        public List<DeThiViewModel> LayDanhSachDeThiBUS()
        {
            return QLDeThiDAO.LayDanhSachDeThiDAO();
        }

        public void Dispose()
        {
            if (QLDeThiDAO != null) { QLDeThiDAO.Dispose(); }
        }
    }
}
