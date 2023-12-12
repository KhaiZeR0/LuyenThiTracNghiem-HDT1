using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP.BUS
{
    public class resetPassBUS
    {
        public class ResetPassBUS
        {
            public static bool VerifyCode(string inputCode, string generatedCode)
            {
                return inputCode == generatedCode;
            }
        }
    }
}
