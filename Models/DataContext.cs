using CharityApplication.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CharityApplication.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dbString")
        {

        }
         public DbSet<cause> Causes { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<organization> Organizations { get; set; }
        public DbSet<donation> Donations { get; set; }
    }
}