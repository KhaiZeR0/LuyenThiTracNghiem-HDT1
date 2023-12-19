using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___OOP
{
    public class Session
    {
        private static Session _instance;

        public static Session Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Session();
                }
                return _instance;
            }
        }

        public string MaTK { get; private set; }

        public void SetMaTK(string maTK)
        {
            MaTK = maTK;
        }

        public void ClearSession()
        {
            MaTK = null;
        }
    }
}
