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
        public List<DeThi> GetDeThiTheoMonHocDAO(string MaMH)
        {
            return DbContext.DeThis.Where(c => c.MaMH == MaMH ).ToList();
        }
    }
}
