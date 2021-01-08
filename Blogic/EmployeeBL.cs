using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Bussiness_Entities;

namespace Blogic
{
    public class EmployeeBL
    {
        EmployeeDAL ob = new EmployeeDAL();
        public CustomEntities AddEmployee(EmployeeEntites empl)
        {

            return ob.AddEmployee(empl);
        }

        public int ValidateEmployee(string username, string password)
        {
            return ob.ValidateEmployee(username, password);

        }

        public int ValidatePanCus(string p)
        {
            return ob.ValidatePanCus(p);

        }
        public int ValidatePanEmp(string p)
        {
            return ob.ValidatePanEmp(p);

        }
        public int DeActivateCustomer(string custid)
        {
            return ob.DeActivateCustomer(custid);
        }
    }
}