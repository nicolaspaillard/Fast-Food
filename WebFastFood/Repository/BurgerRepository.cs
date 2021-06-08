using Dal;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Repository.IRepositories;

namespace WebFastFood.Repository
{
    public class BurgerRepository : IBurgerRepository
    {
        private FastFoodContext context;
        public BurgerRepository(FastFoodContext context)
        {
            this.context = context;
        }
        public void CreateAsync(Burger burger)
        {
            context.Burgers.Add(burger);
            context.SaveChangesAsync();
        }
        public void DeleteAsync(Burger burger)
        {
            context.Burgers.Remove(burger);
            context.SaveChangesAsync();
        }
        public async Task<List<Burger>> GetBurgersAsync()
        {
            return await context.Burgers.ToListAsync();
        }
        public async Task<Burger> GetBurgerAsync(int id)
        {
            return await context.Burgers.FindAsync(id);
        }
        public void UpdateAsync(Burger newBurger)
        {
            context.Burgers.First(b => b.Id == newBurger.Id).Name = newBurger.Name;
            context.Burgers.First(b => b.Id == newBurger.Id).Description = newBurger.Description;
            context.Burgers.First(b => b.Id == newBurger.Id).Price = newBurger.Price;
            context.Burgers.First(b => b.Id == newBurger.Id).Weight = newBurger.Weight;
            context.Burgers.First(b => b.Id == newBurger.Id).BeefWeight = newBurger.BeefWeight;
            context.SaveChangesAsync();
        }
    }
}
