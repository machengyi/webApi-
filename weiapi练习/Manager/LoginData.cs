using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weiapi练习.Models;

namespace weiapi练习.Manager
{
    public class LoginData
    {
        private DB db = new DB();

        public StaffTable UsersInfo(string AccountNum, string password)
        {
            StaffTable st = db.StaffTable.SingleOrDefault(p => p.AccountNumber == AccountNum && p.Password == password);
            return st;
        }
    }
}