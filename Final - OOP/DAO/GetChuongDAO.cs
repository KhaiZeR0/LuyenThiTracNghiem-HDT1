using Final___OOP.DAO.Model;
using System.Collections.Generic;
using System.Linq;

namespace Final___OOP.DAO
{
    public class GetChuongDAO : ThiTracNghiemDAO
    {
        public List<Chuong> GetChuong()
        {
            return DbContext.Chuongs.ToList();
        }
    }
}
