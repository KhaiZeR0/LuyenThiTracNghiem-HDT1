using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class BaiThiBUS : IDisposable
    {
        private BaiThiDAO baiThiDAO;
        public BaiThiBUS()
        {
            baiThiDAO = new BaiThiDAO();
        }

        public List<CauHoi> GetMaCauHoiBaiLamBUS(string maCauHoi)
        {
            return baiThiDAO.GetCauHoiBaiLamDAO(maCauHoi);
        }
        public void AddBaiThiBUS(string maBaiLam, string maHS, string baiLam)
        {
            baiThiDAO.AddBaiLamHSDAO(maBaiLam, maHS, baiLam);
        }
        public void Dispose()
        {
            if (baiThiDAO != null) { baiThiDAO.Dispose(); }
        }
    }
}
