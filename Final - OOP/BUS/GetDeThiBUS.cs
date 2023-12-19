using Final___OOP.DAO.Model;
using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    public class GetDeThiBUS : IDisposable
    {
        private GetDeThiDAO dethiDAO;
        public GetDeThiBUS()
        {
            dethiDAO = new GetDeThiDAO();
        }

        public List<DeThi> GetAllDeThi()
        {
            return dethiDAO.GetDeThi();
        }

        public void Dispose()
        {
            if (dethiDAO != null) { dethiDAO.Dispose(); }
        }
    }
}
