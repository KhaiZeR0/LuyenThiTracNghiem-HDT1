using Final___OOP.DAO;
using Final___OOP.DAO.Model;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Final___OOP
{
    public class ResetPassDAO : ThiTracNghiemDAO
    {
        public void UpdateMatKhau(string email, string newMatKhau)
        {
            var taiKhoan = GetTaiKhoanByEmail(email);

            if (taiKhoan != null)
            {
                string hashedMatKhau = GetSHA256Hash(newMatKhau);
                taiKhoan.MatKhau = hashedMatKhau;
                DbContext.SaveChanges();
            }
        }

        private TaiKhoan GetTaiKhoanByEmail(string email)
        {
            return DbContext.TaiKhoans.FirstOrDefault(tk => tk.Email == email);
        }
        public string GetSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
