using Final___OOP.DAO.Model;
using System.Collections.Generic;
using System.Linq;

namespace Final___OOP.DAO
{
    public class GetChungDAO : ThiTracNghiemDAO
    {
        public List<LopHoc> GetLopHoc()
        {
            return DbContext.LopHocs.ToList();
        }
        public List<Chuong> GetChuong(string maMonHoc)
        {
            return DbContext.Chuongs.Where(c => c.MaMH == maMonHoc).ToList();
        }

        public List<MonHoc> GetMonHocs()
        {
            return DbContext.MonHocs.ToList();
        }
    }
}
