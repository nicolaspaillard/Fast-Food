using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Dal
{
    public class FastFoodContext: DbContext

    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Menu> Menus { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FastFood;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
