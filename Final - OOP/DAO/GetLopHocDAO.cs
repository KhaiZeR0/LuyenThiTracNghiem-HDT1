using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    internal class GetLopHocDAO
    {
        private ThiTracNghiemModelEntities db;
        public GetLopHocDAO()
        {
            db = new ThiTracNghiemModelEntities();
        }
        public List<Lophoc> GetLopHoc()
        {
            return db.Lophocs.ToList();
        }
    }
}
