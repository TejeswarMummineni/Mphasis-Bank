using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Bussiness_Entities;

namespace Blogic
{

    public class LoanBL
    {
        LoanDAL ld = new LoanDAL();
        CustomerEntities ce = new CustomerEntities(); 
        public int LoanAc(Loan_Account_Entites la)
        {
           return ld.LoanAc(la);      
        }
        public int LoanTrans(Loan_Transcation_Entites lt)
        {
            return ld.LoanTrans(lt);
        }
    }
}
