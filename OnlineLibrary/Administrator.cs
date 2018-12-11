using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Administrator
    {
        private static Administrator admin;
        private static string username = "admin";
        private static string password = "12345";

        public static Administrator GetObject()
        {
            if (admin == null)
            {
                admin = new Administrator();
            }
            return admin;
        }

        public static string Username { get { return username; } }
        public static string Password { get { return password; } set { password = value; } }
    }
}
