using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    public class CauHoiBUS : IDisposable
    {
        private CauHoiDAO cauHoiDAO;

        public CauHoiBUS() { cauHoiDAO = new CauHoiDAO(); }

        public void AddCauHoiBUS(string maCauHoi, string noiDung, string dapAnA, string dapAnB, string dapAnC,
            string dapAnD, string dapAnDung, string maMonHoc, string maChuong)
        {
            cauHoiDAO.AddCauHoiDAO(maCauHoi, noiDung, dapAnA, dapAnB, dapAnC,
            dapAnD, dapAnDung, maMonHoc, maChuong);
        }

        public void UpdateCauHoiBUS(string maCauHoi, string noiDung, string dapAnA, string dapAnB, string dapAnC,
            string dapAnD, string dapAnDung, string maMH, string maChuong)
        {
            cauHoiDAO.UpdateCauHoiDAO(maCauHoi, noiDung, dapAnA, dapAnB, dapAnC,
            dapAnD, dapAnDung, maMH, maChuong);
        }

        public List<CauHoi> LayDanhSachCauHoiBUS()
        {
            return cauHoiDAO.LayDanhSachCauHoiDAO();
        }

        public void DeleteCauHoiBUS(string maMH)
        {
            cauHoiDAO.DeleteCauHoiDAO(maMH);
        }
        public void Dispose()
        {
            if (cauHoiDAO != null) { cauHoiDAO.Dispose(); }
        }
    }
}
