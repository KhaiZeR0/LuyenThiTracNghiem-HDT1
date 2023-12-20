using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    internal class GetDSLopTuMaHSBUS : IDisposable
    {
        private GetDSLopTuMaHSDAO getDSDAO;
        public GetDSLopTuMaHSBUS() 
        {
            getDSDAO = new GetDSLopTuMaHSDAO();
        }
        public List<DanhSachLop> getDSLopBUS(string maHS)
        {
            return getDSDAO.getDSLopDAO(maHS);
        }

        public void Dispose()
        {
            if ( getDSDAO!= null) { getDSDAO.Dispose(); }
        }
    }
}
