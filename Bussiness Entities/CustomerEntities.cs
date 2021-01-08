using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussiness_Entities
{
    public class CustomerEntities
    {

        public string CustId { get; set; }

        [Display(Name = "Customer name")]
        [Required]
        [StringLength(25,ErrorMessage ="Name not be exceed")]
        public string CustName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public Nullable<System.DateTime> Dob { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Pan Number should be 8 Charters Long")]
        public string Pan { get; set; }

        public string Accountid { get; set; }

        public int balance { get; set; }
        public bool Status { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; }
        public string Code { get; set; }

    }
    
}
