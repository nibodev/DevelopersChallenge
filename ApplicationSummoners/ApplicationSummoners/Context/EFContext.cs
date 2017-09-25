using ApplicationSummoners.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ApplicationSummoners.Context
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("AppGamer")//String de conexão
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Kingdom> Kingdom { get; set; }
    }
}