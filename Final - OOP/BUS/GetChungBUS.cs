using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;

namespace Final___OOP.BUS
{
    internal class GetChungBUS : IDisposable
    {
        private GetChungDAO getChungDAO;
        public GetChungBUS()
        {
            getChungDAO = new GetChungDAO();
        }

        public List<LopHoc> GetAllLopHoc()
        {
            return getChungDAO.GetLopHoc();
        }
        public List<MonHoc> GetAllMonHoc()
        {
            return getChungDAO.GetMonHocs();
        }
        public List<Chuong> GetAllChuong(string maMonHoc)
        {
            return getChungDAO.GetChuong(maMonHoc);
        }

        public void Dispose()
        {
            if (getChungDAO != null) { getChungDAO.Dispose(); }
        }
    }
}
