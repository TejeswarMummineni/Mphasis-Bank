using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Bussiness_Entities;

namespace DAL
{
    public class CustomerDAL
    {
        private MphasisBankEntities dbEntites;
        public CustomerDAL()
        {
            dbEntites = new MphasisBankEntities();
        }

        public int AddCustomer(CustomerEntities ce)
        {
            var res = (from c in dbEntites.Employees
                       where c.Pan == ce.Pan
                       select c).Count();
            var res2 = (from c in dbEntites.Customers
                        where c.Pan == ce.Pan
                        select c).Count();
            if (res > 0 || res2 > 0)
            {
                return 0;
            }
            else
            {
              
                var cd =dbEntites.Customers.OrderByDescending(t => t.CustId).FirstOrDefault();
                if (cd == null)
                {
                    ce.CustId = "MLA10001";
                }
                else
                {
                    ce.CustId = "MLA" + (Convert.ToInt32(cd.CustId.Substring(3,5)) + 1).ToString();
                }
                Customer c = new Customer()
                {
                    CustId = ce.CustId,
                    CustName = ce.CustName,
                    Pan = ce.Pan,
                    Dob = ce.Dob,
                    Password = ce.Password,
                    Status = true,
                    Email=ce.Email
                };
                dbEntites.Customers.Add(c);

                var ac = dbEntites.SavingsAccounts.OrderByDescending(t => t.Accountid).FirstOrDefault();
                if (ac == null)
                {
                    ce.Accountid = "SB10001";
                }
                else
                {
                    ce.Accountid = "SB" + (Convert.ToInt32(ac.Accountid.Substring(2, 5)) + 1).ToString();
                }
                SavingsAccount sac = new SavingsAccount()
                {
                    
                    Accountid = ce.Accountid,
                    CustId=ce.CustId,
                    Balance = ce.balance
                };
                dbEntites.SavingsAccounts.Add(sac);
                dbEntites.SaveChanges();

                return 1;
            }

        }
        
       
    }
       
}
