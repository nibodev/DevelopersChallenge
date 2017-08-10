using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Project.Repository.Entities;

namespace Project.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base(ConfigurationManager.ConnectionStrings["banco"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Team> Team { get; set; }
        public DbSet<Deleted> Deleted { get; set; }
        public DbSet<TeamRelationship> TeamRelationship { get; set; }
    }
}
