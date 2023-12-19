using Final___OOP.DAO.Model;
using System.Collections.Generic;
using System.Linq;

namespace Final___OOP.DAO
{
    public class GetMonHocDAO : ThiTracNghiemDAO
    {
        public List<MonHoc> GetMonHoc()
        {
            return DbContext.MonHocs.ToList();
        }
    }
}
