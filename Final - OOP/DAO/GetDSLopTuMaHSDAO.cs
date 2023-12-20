using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    internal class GetDSLopTuMaHSDAO : ThiTracNghiemDAO
    {
        public List<DanhSachLop> getDSLopDAO(string maHS)
        {
            return DbContext.DanhSachLops.Where(c => c.MaSV == maHS).ToList();
        }
    }
}
