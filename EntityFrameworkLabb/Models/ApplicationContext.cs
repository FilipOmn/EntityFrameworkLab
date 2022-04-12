using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkLabb.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employe> Employees { get; set; }
        public DbSet<LeaveApplication> Applications { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FFB4Q97\SQLEXPRESS;Initial Catalog=LeaveApplications;Integrated Security=True");
        }
    }
}
