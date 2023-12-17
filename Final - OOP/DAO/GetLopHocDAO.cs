using Final___OOP.DAO.Model;
using System.Collections.Generic;
using System.Linq;

namespace Final___OOP.DAO
{
    public class GetLopHocDAO : ThiTracNghiemDAO
    {
        public List<LopHoc> GetLopHoc()
        {
            return DbContext.LopHocs.ToList();
        }
    }
}
