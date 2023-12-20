using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class QLDeThiBUS
    {
        private QLDeThiDAO QLDeThiDAO;
        public QLDeThiBUS()
        {
            QLDeThiDAO = new QLDeThiDAO();
        }
        public void ThemDeThiBUS(string maDeThi, string tenDeThi, TimeSpan thoiGianLamBai, string maMonHoc, string maLop, string maCauHoiString, int soLuong)
        {
            QLDeThiDAO.ThemDeThiDAO(maDeThi, tenDeThi, thoiGianLamBai, maMonHoc, maLop, maCauHoiString, soLuong);
        }

        public List<CauHoi_View> GetCauHoiByChuongBUS(string maChuong)
        {
            return QLDeThiDAO.GetCauHoiByChuongDAO(maChuong);
        }
        public List<CauHoi_View> GetCauHoiBUS(string maCauHoi)
        {
            return QLDeThiDAO.GetCauHoiDAO(maCauHoi);
        }

        public void Dispose()
        {
            if (QLDeThiDAO != null) { QLDeThiDAO.Dispose(); }
        }
    }
}
