using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_Account
    {
        DAL_Account dalAccount = new DAL_Account();
        public int getType(string id, string password)
        {
            return dalAccount.getType(id, password);
        }

        public bool checkPassword(String username, String password, String newPass)
        {
            return dalAccount.checkPassword(username, password, newPass);
        }
    }
}
