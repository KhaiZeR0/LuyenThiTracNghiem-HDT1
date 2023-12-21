using Final___OOP.BUS;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final___OOP.DAO
{
    public class KetQuaThi
    {
        public string MaDeThi;
        public string MaSV;
        public string HoTen;
        public DateTime NgaySinh;
        public string TenLop;
        public int SoLuongCau;
        public string DapAnDaChon;
        public string MaMH;
        public float Diem;
    }

    public class TraCuuSinhVien
    {
        private string maSV;
        private string hoTen;
        private DateTime ngaySinh;
        private string lop;
        private float diem;

        public string MaSV { get => maSV; set => maSV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Lop { get => lop; set => lop = value; }
        public float Diem { get => diem; set => diem = value; }

        public TraCuuSinhVien() { }
    }

    public class TraCuuSinhVienDAO : ThiTracNghiemDAO
    {
        public List<TraCuuSinhVien> LayDanhSachTraCuuDAO(string maLopHoc, string maMH, string maDeThi, string maSV)
        {
            var lsTraCuuSinhVien = new List<TraCuuSinhVien>();
            var ketQuaThi = (from dethi in DbContext.DeThis
                             join monhoc in DbContext.MonHocs on dethi.MaMH equals monhoc.MaMH
                             join lophoc in DbContext.LopHocs on dethi.MaLop equals lophoc.MaLop
                             join bailam in DbContext.BaiLams on dethi.MaDeThi equals bailam.MaBaiLam
                             join thongtinsv in DbContext.ThongTinSVs on bailam.MaSV equals thongtinsv.MaSV
                             where lophoc.MaLop == maLopHoc && dethi.MaMH == maMH && dethi.MaDeThi == maDeThi.Trim().ToString() && (maSV == null || thongtinsv.MaSV == maSV)
                             select new KetQuaThi
                             {
                                 MaDeThi = dethi.MaDeThi,
                                 MaSV = thongtinsv.MaSV,
                                 HoTen = thongtinsv.HoTen,
                                 NgaySinh = thongtinsv.NgaySinh,
                                 TenLop = lophoc.TenLop,
                                 SoLuongCau = dethi.SoLuongCau,
                                 DapAnDaChon = bailam.DapAnDaChon,
                                 MaMH = dethi.MaMH
                             }).ToList();

            UpdateDiem(ketQuaThi);

            foreach (var ketQua in ketQuaThi)
            {
                TraCuuSinhVien traCuuSinhVien = new TraCuuSinhVien();
                traCuuSinhVien.MaSV = ketQua.MaSV;
                traCuuSinhVien.HoTen = ketQua.HoTen;
                traCuuSinhVien.NgaySinh = ketQua.NgaySinh;
                traCuuSinhVien.Lop = ketQua.TenLop;
                traCuuSinhVien.Diem = ketQua.Diem;
                lsTraCuuSinhVien.Add(traCuuSinhVien);
            }

            return lsTraCuuSinhVien;

        }

        private void UpdateDiem(List<KetQuaThi> ketQuaThi)
        {
            foreach (var ketqua in ketQuaThi)
            {
                var listDapAn = ketqua.DapAnDaChon.Split(',');
                var cauHoi = DbContext.CauHois.Where(p => p.MaMH == ketqua.MaMH).Select(p => p.DapAnDung).ToArray();
                int soCauDung = 0;
                for (int i = 0; i < listDapAn.Length; i++)
                {
                    if (listDapAn[i].Trim().Equals(cauHoi[i].Trim()))
                        soCauDung++;
                }
                ketqua.Diem = soCauDung * 10 / ketqua.SoLuongCau;
            }
        }
    }
}
