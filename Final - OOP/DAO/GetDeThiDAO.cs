using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    public class GetDeThiDAO : ThiTracNghiemDAO
    {
        public List<DeThi> GetDeThi()
        {
            return DbContext.DeThis.ToList();
        }
    }
}
