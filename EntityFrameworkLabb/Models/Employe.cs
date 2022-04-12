using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkLabb.Models
{
    public class Employe
    {
        [Key]
        public int EmployeId { get; set; }
        public string Name { get; set; }
    }
}
