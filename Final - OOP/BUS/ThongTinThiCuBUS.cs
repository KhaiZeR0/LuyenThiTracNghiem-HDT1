using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class ThongTinThiCuBUS
    {
        private ThongTinThiCuDAO thongTinThiCuDAO;
        public ThongTinThiCuBUS()
        {
            thongTinThiCuDAO = new ThongTinThiCuDAO();
        }
        public List<DeThi> GetDeThiTheoMH_MaLopBUS(string MaMH, string maLop)
        {
            return thongTinThiCuDAO.GetDeThiTheoMH_MaLopDAO(MaMH, maLop);
        }
    }
}
