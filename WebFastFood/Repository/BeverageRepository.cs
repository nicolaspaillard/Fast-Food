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
    public class BeverageRepository : IBeverageRepository
    {
        private FastFoodContext context;
        public BeverageRepository(FastFoodContext context) {
            this.context = context;
        }
        public async Task<int> CreateAsync(Beverage beverage)
        {
            context.Beverages.Add(beverage);
            return await context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(Beverage beverage)
        {
            context.Beverages.Remove(beverage);
            return await context.SaveChangesAsync();
        }
        public async Task<List<Beverage>> GetBeveragesAsync()
        {
            return await context.Beverages.ToListAsync();
        }
        public async Task<Beverage> GetBeverageAsync(int id)
        {
            return await context.Beverages.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> UpdateAsync(Beverage newBeverage)
        {
            context.Beverages.First(b => b.Id == newBeverage.Id).Name = newBeverage.Name;
            context.Beverages.First(b => b.Id == newBeverage.Id).Description = newBeverage.Description;
            context.Beverages.First(b => b.Id == newBeverage.Id).Price = newBeverage.Price;
            context.Beverages.First(b => b.Id == newBeverage.Id).IsCarbonated = newBeverage.IsCarbonated;
            context.Beverages.First(b => b.Id == newBeverage.Id).Millimeter = newBeverage.Millimeter;
            return await context.SaveChangesAsync();
        }
    }
}
