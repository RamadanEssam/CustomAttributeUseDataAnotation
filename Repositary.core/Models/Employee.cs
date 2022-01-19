using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary.core.Models
{
    public class Employee
    {
        public int id { get; set; }
        [Required]
        [MaxLength(10 , ErrorMessage ="Max len 10")]
        [MinLength(4 ,ErrorMessage ="Min len 4")]
        public string Name { get; set; }
        [Range(18,35 ,ErrorMessage ="Age must between 18 to 35")]
        public int Age { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
