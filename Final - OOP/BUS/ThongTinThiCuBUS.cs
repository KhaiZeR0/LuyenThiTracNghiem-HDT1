using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class ThongTinThiCuBUS : IDisposable
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
        public List<DeThi> GetDTtheoMaDeThiBUS(string maDT)
        {
            return thongTinThiCuDAO.getDTtheoMaDeThiDAO(maDT);
        }
        public List<DeThi> GetDeThiDaLamTheoMaSV(string maSV)
        {
            return thongTinThiCuDAO.GetDeThiDaLamTheoMaSVDAO(maSV);
        }
        public List<BaiLam> getBaiLam(string maHS, string maBaiThi)
        {
            return thongTinThiCuDAO.getBaiLamDAO(maHS, maBaiThi);
        }

        public void Dispose()
        {
            if (thongTinThiCuDAO != null) { thongTinThiCuDAO.Dispose(); }
        }
    }
}
