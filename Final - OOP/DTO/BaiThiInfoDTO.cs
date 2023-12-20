using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DTO
{
    public class BaiThiInfoDTO
    {
        private string maDeThi;
        private TimeSpan tGLamBai;
        private int soLuongCau;
        private string maCauHoi;
        private string DapAnDaChon;
  


        public TimeSpan TGLamBai { get => tGLamBai; set => tGLamBai = value; }
        public int SoLuongCau { get => soLuongCau; set => soLuongCau = value; }
        public string MaCauHoi { get => maCauHoi; set => maCauHoi = value; }
        public string MaDeThi { get => maDeThi; set => maDeThi = value; }
        public string DapAnDaChon1 { get => DapAnDaChon; set => DapAnDaChon = value; }

        public BaiThiInfoDTO() { }
    }
}
