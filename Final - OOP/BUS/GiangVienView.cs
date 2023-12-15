using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class GiangVienView
    {
        private string maGV;
        private string hoTen;
        private DateTime ngaySinh;
        private string diaChi;
        private string email;
        private bool gioiTinh;

        public string MaGV { get => maGV; set => maGV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        public GiangVienView() { }
    }
}
