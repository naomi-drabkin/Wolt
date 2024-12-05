using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Wolt.Core.Models;

namespace Wolt.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Orders> orders_list { get; set; }
        public DbSet<Supply_company> companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=sample_db");
        }
    }
}
