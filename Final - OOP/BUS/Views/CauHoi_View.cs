using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class CauHoi_View
    {
        private string maCauHoi;
        private string noiDungCauHoi;
        private string dapAn_A;
        private string dapAn_B;
        private string dapAn_C;
        private string dapAn_D;
        private string dapAnDung;


        public string MaCauHoi { get => maCauHoi; set => maCauHoi = value; }
        public string NoiDungCauHoi { get => noiDungCauHoi; set => noiDungCauHoi = value; }
        public string DapAn_A { get => dapAn_A; set => dapAn_A = value; }
        public string DapAn_B { get => dapAn_B; set => dapAn_B = value; }
        public string DapAn_C { get => dapAn_C; set => dapAn_C = value; }
        public string DapAn_D { get => dapAn_D; set => dapAn_D = value; }
        public string DapAnDung { get => dapAnDung; set => dapAnDung = value; }


        public CauHoi_View() { }
    }
}
