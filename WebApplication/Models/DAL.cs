using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class AnimalContext : DbContext
    {
        public AnimalContext() : base(GetConnection(), false)
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<AnimalContext>(null);
        }

        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<EventData> EventDataValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static DbConnection GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["MyDBContext"];
            var dbLocation = ConfigurationManager.AppSettings["DBLocation"];
            string connString = connection.ConnectionString.Replace("{DBLocation}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbLocation));
            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
            var dbCon = factory.CreateConnection();
            dbCon.ConnectionString = connString;
            return dbCon;
        }

    }
}