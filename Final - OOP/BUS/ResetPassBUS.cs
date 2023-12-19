using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;

namespace Final___OOP
{
    public class ResetPassBUS : IDisposable
    {
        private readonly ResetPassDAO resetPassDAO;
        public ResetPassBUS()
        {
            resetPassDAO = new ResetPassDAO();
        }

        public bool KiemTraMatKhauHopLe(string matKhau, string xacNhanMatKhau)
        {
            string hashedMatKhau = resetPassDAO.GetSHA256Hash(matKhau);
            string hashedXacNhanMatKhau = resetPassDAO.GetSHA256Hash(xacNhanMatKhau);

            return hashedMatKhau == hashedXacNhanMatKhau;
        }

        public void CapNhatMatKhau(string email, string matKhau)
        {
            resetPassDAO.UpdateMatKhau(email, matKhau);
        }

        public void Dispose()
        {
            if (resetPassDAO != null) { resetPassDAO.Dispose(); }
        }

    }
}
