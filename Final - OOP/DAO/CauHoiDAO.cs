using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    public class CauHoiDAO : ThiTracNghiemDAO
    {
        public void AddCauHoiDAO(string maCauHoi, string noiDung, string dapAnA, string dapAnB, string dapAnC,
            string dapAnD, string dapAnDung, string maMonHoc, string maChuong)
        {
            var newCauHoi = new CauHoi
            {
                MaCauHoi = maCauHoi,
                NoiDungCauHoi = noiDung,
                DapAnA = dapAnA,
                DapAnB = dapAnB,
                DapAnC = dapAnC,
                DapAnD = dapAnD,
                DapAnDung = dapAnDung,
                MaChuong = maChuong,
                MaMH = maMonHoc
            };
            DbContext.CauHois.Add(newCauHoi);
            DbContext.SaveChanges();
        }

        public void UpdateCauHoiDAO(string maCauHoi, string noiDung, string dapAnA, string dapAnB, string dapAnC,
            string dapAnD, string dapAnDung, string maMH, string maChuong)
        {
            var cauHoiToUpdate = DbContext.CauHois.FirstOrDefault(p => p.MaCauHoi == maCauHoi);

            if (cauHoiToUpdate != null)
            {
                cauHoiToUpdate.NoiDungCauHoi = noiDung;
                cauHoiToUpdate.DapAnA = dapAnA;
                cauHoiToUpdate.DapAnB = dapAnB;
                cauHoiToUpdate.DapAnC = dapAnC;
                cauHoiToUpdate.DapAnD = dapAnD;
                cauHoiToUpdate.DapAnDung = dapAnDung;
                cauHoiToUpdate.MaChuong = maChuong;
                cauHoiToUpdate.MaMH = maMH;
                DbContext.SaveChanges();
            }
        }

        public void DeleteCauHoiDAO(string maCauHoi)
        {
            var monHocToDelete = DbContext.CauHois.FirstOrDefault(p => p.MaCauHoi == maCauHoi);

            if (monHocToDelete != null)
            {
                DbContext.CauHois.Remove(monHocToDelete);
                DbContext.SaveChanges();
            }
        }

        public List<CauHoi> LayDanhSachCauHoiDAO()
        {
            return DbContext.CauHois.ToList();
        }
    }
}
