using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Outlook_Signatures_Management.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Signature> Signatures { get; set; }
    }
}