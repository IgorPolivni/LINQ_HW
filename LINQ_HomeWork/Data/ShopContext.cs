using LINQ_HomeWork.DataClasses;
using LINQ_HomeWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_HomeWork.Data 
{
    public class ShopContext : DbContext
{
        public ShopContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Smartphone> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-619RM10; Database = LINQHW; Trusted_connection = true;");
        }
    }
}
