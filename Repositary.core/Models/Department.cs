using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary.core.Models
{
    public class Department
    {
        public int id { get; set; }

        [Required]
        [MaxLength(120 , ErrorMessage ="Max len 120")]
        [MinLength(4 , ErrorMessage ="Min Len 4")]
        public string Name { get; set; }
    }
}
