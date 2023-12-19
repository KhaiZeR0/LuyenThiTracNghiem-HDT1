using Final___OOP.DAO.Model;
using Final___OOP.DAO;
using System;
using System.Collections.Generic;

namespace Final___OOP.BUS
{
    public class GetChuongBUS : IDisposable
    {
        private GetChuongDAO chuongDAO;
        public GetChuongBUS()
        {
            chuongDAO = new GetChuongDAO();
        }

        public List<Chuong> GetAllChuong()
        {
            return chuongDAO.GetChuong();
        }

        public void Dispose()
        {
            if (chuongDAO != null) { chuongDAO.Dispose(); }
        }
    }
}
