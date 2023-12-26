using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    internal class ThongTinThiCuDAO : ThiTracNghiemDAO
    {
        public List<DeThi> GetDeThiTheoMH_MaLopDAO(string MaMH, string maLop = null)
        {
            var query = DbContext.DeThis.Where(c => c.MaMH == MaMH);

            if (!string.IsNullOrEmpty(maLop))
            {
                query = query.Where(c => c.MaLop == maLop);
            }

            return query.ToList();
        }
        public List<DeThi> GetDeThiDaLamTheoMaSVDAO(string maSV)
        {
            var query = DbContext.BaiLams
                .Where(bl => bl.MaSV == maSV && bl.TrangThai == true)  
                .Select(bl => bl.DeThi)
                .Distinct();

            return query.ToList();
        }
        public List<BaiLam> getBaiLamDAO(string maHS, string maBaiThi)
        {
            var query = DbContext.BaiLams.Where(bl => bl.MaBaiLam == maBaiThi && bl.MaSV == maHS).ToList();

            return query.ToList();
        }

    }
}
