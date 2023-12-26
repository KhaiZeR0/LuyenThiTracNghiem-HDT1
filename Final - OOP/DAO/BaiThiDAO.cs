using Final___OOP.DAO.Model;
using Final___OOP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    internal class BaiThiDAO : ThiTracNghiemDAO
    {
        public List<CauHoi> GetCauHoiBaiLamDAO(string maCauHoi)
        {
            return DbContext.CauHois.Where(c => c.MaCauHoi == maCauHoi).ToList();
        }
        public void AddBaiLamHSDAO(string maDeThi, string maHS, string dapAnDaChon)
        {
            var newBaiLam = new BaiLam
            {
                MaBaiLam = maDeThi,
                MaSV = maHS,
                DapAnDaChon = dapAnDaChon,
            };
            DbContext.BaiLams.Add(newBaiLam);
            DbContext.SaveChanges();
        }
    }
}
