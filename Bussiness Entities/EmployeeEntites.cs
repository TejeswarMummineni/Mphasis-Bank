using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bussiness_Entities
{
    public class EmployeeEntites
    {
        public int Empid { get; set; }
        [Required(ErrorMessage ="Username field is Required")]
        public string EmpName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Pan { get; set; }
    }
}
