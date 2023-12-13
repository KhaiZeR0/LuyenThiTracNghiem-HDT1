using Final___OOP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    public class GetAllLopHocBUS
    {
        private GetAllLopHocDAO GetLopHocDAO;

        public GetAllLopHocBUS()
        {
            GetLopHocDAO = new GetAllLopHocDAO(); // Khởi tạo DAO trong BUS
        }

        public List<Lophoc> GetAllLopHoc()
        {
            return GetLopHocDAO.GetAllLopHoc();
        }
    }
}
