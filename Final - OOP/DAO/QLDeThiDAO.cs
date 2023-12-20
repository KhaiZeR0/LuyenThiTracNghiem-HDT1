using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___OOP.DAO
{
    internal class QLDeThiDAO : ThiTracNghiemDAO
    {

        public void ThemDeThiDAO(string maDeThi, string tenDeThi, TimeSpan thoiGianLamBai, string maMonHoc, string maLop, string maCauHoiString, int soLuongCauHoi)
        {

            try
            {
                DeThi deThi = new DeThi
                {
                    MaDeThi = maDeThi,
                    TenDeThi = tenDeThi,
                    TGLamBai = thoiGianLamBai,
                    MaMH = maMonHoc,
                    MaLop = maLop,
                    NoiDungDeThi = maCauHoiString,
                    SoLuongCau = soLuongCauHoi
                };

                DbContext.DeThis.Add(deThi);
                DbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex);
            }
        }

        public List<CauHoi_View> GetCauHoiByChuongDAO(string maChuong)
        {
            var query = from cauHoi in DbContext.CauHois
                        join chuong in DbContext.Chuongs on cauHoi.MaChuong equals chuong.MaChuong
                        where chuong.MaChuong == maChuong
                        select new CauHoi_View
                        {
                            MaCauHoi = cauHoi.MaCauHoi,
                            NoiDungCauHoi = cauHoi.NoiDungCauHoi,
                            DapAn_A = cauHoi.DapAnA,
                            DapAn_B = cauHoi.DapAnB,
                            DapAn_C = cauHoi.DapAnC,
                            DapAn_D = cauHoi.DapAnD,
                            DapAnDung = cauHoi.DapAnDung,
                        };

            return query.ToList();
        }

        public List<CauHoi_View> GetCauHoiDAO(string maCauHoi)
        {
            var query = from cauHoi in DbContext.CauHois
                        join chuong in DbContext.Chuongs on cauHoi.MaChuong equals chuong.MaChuong
                        where string.IsNullOrEmpty(maCauHoi) || cauHoi.MaCauHoi == maCauHoi
                        select new CauHoi_View
                        {
                            MaCauHoi = cauHoi.MaCauHoi,
                            NoiDungCauHoi = cauHoi.NoiDungCauHoi,
                            DapAn_A = cauHoi.DapAnA,
                            DapAn_B = cauHoi.DapAnB,
                            DapAn_C = cauHoi.DapAnC,
                            DapAn_D = cauHoi.DapAnD,
                            DapAnDung = cauHoi.DapAnDung,
                        };

            return query.ToList();
        }
    }
}
