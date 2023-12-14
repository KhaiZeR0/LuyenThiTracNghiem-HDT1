using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class GetLopHocBUS
    {
        private GetLopHocDAO LopHocDao;
        public GetLopHocBUS() 
        {
            LopHocDao = new GetLopHocDAO();
        }
        public List<Lophoc> GetAllLopHoc()
        {
            return LopHocDao.GetLopHoc();
        }
    }
}
