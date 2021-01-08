using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Entities;
using DAL.Models;

namespace DAL
{
    public class LoginDAL
    {
        private MphasisBankEntities db;
        public LoginDAL()
        {
            db = new MphasisBankEntities();
        }

        public int Loginvalidate(LoginEntites log)
        {
            int r ;
            var emp = db.Employees.Where(e => e.EmpName == log.Username && e.Password == log.Password).Count();
            var cust = db.Customers.Where(c => c.CustName == log.Username && c.Password == log.Password).Count();
            if (emp > 0)
            {
                r=1;
            }
            else if(cust > 0)
            {
                r=2;
            }
            else if (log.Username =="Manager" && log.Password =="india")
            {
                r = 3;
            }
            else
            {
                r = 0;
            }
            return r;
        }
    }
}
