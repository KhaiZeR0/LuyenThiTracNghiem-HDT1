using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Final___OOP.BUS.QLDeThiBUS;

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

        public void XoaDeThiDAO(string maDeThi)
        {
            try
            {
                var deThi = DbContext.DeThis.SingleOrDefault(dt => dt.MaDeThi == maDeThi);
                if (deThi != null)
                {
                    DbContext.DeThis.Remove(deThi);
                    DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
        }
        public List<DeThiViewModel> LayDanhSachDeThiDAO()
        {
            var query = from dt in DbContext.DeThis
                        join lop in DbContext.LopHocs on dt.MaLop equals lop.MaLop
                        join monhoc in DbContext.MonHocs on dt.MaMH equals monhoc.MaMH
                        select new DeThiViewModel
                        {
                            MaDeThi = dt.MaDeThi,
                            TenDeThi = dt.TenDeThi,
                            TGLamBai = dt.TGLamBai,
                            SoLuongCau = dt.SoLuongCau,
                            MaCB = dt.MaCB,
                            TenLop = lop.TenLop, // Change from MaLop
                            TenMH = monhoc.TenMH // Change from MaMH
                        };

            return query.ToList();
        }
    }
}
