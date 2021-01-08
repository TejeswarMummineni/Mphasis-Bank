using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Entities;
using DAL;

namespace Blogic
{
    public class CustomerBL
    {
        CustomerDAL cd = new CustomerDAL();
        
        public int AddCustomer(CustomerEntities ce)
        { 
             return cd.AddCustomer(ce);
        }
        
    }
          
    
}
     