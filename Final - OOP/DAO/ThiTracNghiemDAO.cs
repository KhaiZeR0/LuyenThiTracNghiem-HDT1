using Final___OOP.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    public class ThiTracNghiemDAO : IDisposable
    {
        private ThiTracNghiemEntities _dbContext;

        public ThiTracNghiemDAO()
        {
            _dbContext = new ThiTracNghiemEntities();
        }

        public ThiTracNghiemEntities DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
