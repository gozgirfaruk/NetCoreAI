using _001_ApiDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace _001_ApiDemo.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GOZEGIR\\SQLEXPRESS;Database=AIApiDemo;Integrated Security=true;TrustServerCertificate=True;");
        }

        public DbSet<Customer> Customers { get; set; }
    }

}
