using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Entities
{
   public class Loan_Transcation_Entites
    {
        public int LnTransId { get; set; }
        public string LnAccountid { get; set; }
        public Nullable<System.DateTime> Emidate { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<double> Outstanding { get; set; }
    }
}
