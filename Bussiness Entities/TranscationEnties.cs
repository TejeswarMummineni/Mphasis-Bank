using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bussiness_Entities
{
   public class TranscationEnties
    {
        public int TranscationId { get; set; }
        public string Accountid { get; set; }
        public Nullable<System.DateTime> TranscationDate { get; set; }
        public string TranscationType { get; set; }
        public Nullable<int> Balance { get; set; }
       
    }
}
