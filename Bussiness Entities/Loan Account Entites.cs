using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Entities
{
    public class Loan_Account_Entites
    {
        public string LnAccountid { get; set; }
        public string CustId { get; set; }
        public Nullable<int> lnAmount { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> Tenure { get; set; }
        public Nullable<double> ROI { get; set; }
        public Nullable<double> EMI { get; set; }
    }
}
