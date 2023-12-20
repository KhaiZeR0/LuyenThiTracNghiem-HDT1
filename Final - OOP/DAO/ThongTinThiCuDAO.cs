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
    }
}
