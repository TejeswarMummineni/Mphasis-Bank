using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Entities;
using DAL.Models;

namespace DAL
{
    public class EmployeeDAL
    {
        private MphasisBankEntities dbEntites;
        public EmployeeDAL()
        {
            dbEntites = new MphasisBankEntities();
        }
        public CustomEntities AddEmployee(EmployeeEntites empl)
        {
            CustomEntities ce = new CustomEntities();
            Employee emp=new Employee
            {
                EmpName = empl.EmpName,
                Password = empl.Password,
                Pan = empl.Pan
            };
            dbEntites.Employees.Add(emp);
            int returnval = dbEntites.SaveChanges();
            if (returnval > 0)
            {
                ce.CustomMessage = "Data Successfully Added.";
                ce.CustomMessageNumber = returnval;
            }
            else
            {
                ce.CustomMessage = "Something Went Wrong in Adding Employee";
                ce.CustomMessageNumber = returnval;
            }
            return ce;
        }

            
            
            public int ValidateEmployee(string username, string password)
            {

                var res = (from t in dbEntites.Employees
                         where t.EmpName == username && t.Password== password
                         select t).Count();
            if (res > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            public int ValidatePanCus(string p)
            {
                var r = (from c in dbEntites.Customers
                         where c.Pan == p
                         select c).Count();


                if (r > 0)
                {
                    return 1;
                }

                else
                {
                    return 0;
                }
            }
            public int ValidatePanEmp(string p)
            {
                var r = (from c in dbEntites.Employees
                         where c.Pan == p
                         select c).Count();


                if (r > 0)
                {
                    return 1;
                }

                else
                {
                    return 0;
                }
            }  
        public int DeActivateCustomer(string custid)
        {

            var res = dbEntites.Customers.Where(t => t.CustId == custid);
            if (res.Count() > 0)
            {
                foreach (var item in res)
                {
                    item.Status = false;
                }
                dbEntites.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
