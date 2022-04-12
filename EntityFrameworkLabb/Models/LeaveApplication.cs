using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkLabb.Models
{
    public class LeaveApplication
    {
        [Key]
        public int ApplicationId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public virtual Employe Employe { get; set; }
    }
}
