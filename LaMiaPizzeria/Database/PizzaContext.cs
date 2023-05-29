﻿using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.Database
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {   

        
        public DbSet<Pizza> Pizzas{ get; set; }
        public DbSet<PizzaCategory> PizzaCategories { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFPizza;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
