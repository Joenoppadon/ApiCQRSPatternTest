using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiCQRSPatternTest.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}