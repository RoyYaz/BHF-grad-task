using BHF_grad_task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BHF_grad_task.DataAccessLayer
{
    public class BHFContext : DbContext
    {

        public BHFContext() : base("BHFContext")
        {
        }

        public DbSet<User> userDB { get; set; }
        public DbSet<Donation> donateDB { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}