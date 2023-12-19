using Final___OOP.DAO.Model;
using Final___OOP.DAO;
using System.Collections.Generic;
using System;

namespace Final___OOP.BUS
{
    public class GetMonHocBUS : IDisposable
    {
        private GetMonHocDAO monHocDAO;
        public GetMonHocBUS()
        {
            monHocDAO = new GetMonHocDAO();
        }

        public List<MonHoc> GetAllLopHoc()
        {
            return monHocDAO.GetMonHoc();
        }

        public void Dispose()
        {
            if (monHocDAO != null) { monHocDAO.Dispose(); }
        }
    }
}
