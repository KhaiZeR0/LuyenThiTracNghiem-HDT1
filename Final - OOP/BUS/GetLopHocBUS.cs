using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;

namespace Final___OOP.BUS
{
    internal class GetLopHocBUS : IDisposable
    {
        private GetLopHocDAO lopHocDao;
        public GetLopHocBUS() 
        {
            lopHocDao = new GetLopHocDAO();
        }

        public List<LopHoc> GetAllLopHoc()
        {
            return lopHocDao.GetLopHoc();
        }

        public void Dispose()
        {
            if (lopHocDao != null) { lopHocDao.Dispose(); }
        }
    }
}
