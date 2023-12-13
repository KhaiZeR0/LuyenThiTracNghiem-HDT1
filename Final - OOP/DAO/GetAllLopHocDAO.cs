using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.DAO
{
    internal class GetAllLopHocDAO
    {
        private ThiTracNghiemEntities db; // Thay "YourDbContext" bằng tên DbContext của bạn

        public GetAllLopHocDAO()
        {
            db = new ThiTracNghiemEntities(); // Khởi tạo DbContext
        }

        public List<Lophoc> GetAllLopHoc()
        {
            return db.Lophoc.ToList();
        }
    }
}
