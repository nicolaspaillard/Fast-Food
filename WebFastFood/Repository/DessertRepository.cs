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
    public class DessertRepository : IDessertRepository
    {
        private FastFoodContext context;
        public DessertRepository(FastFoodContext context)
        {
            this.context = context;
        }

        public void CreateAsync(Dessert dessert)
        {
            context.Desserts.Add(dessert);
            context.SaveChangesAsync();
        }
        public void DeleteAsync(Dessert dessert)
        {
            context.Desserts.Remove(dessert);
            context.SaveChangesAsync();
        }
        public async Task<List<Dessert>> GetDessertsAsync()
        {
            return await context.Desserts.ToListAsync();
        }
        public async Task<Dessert> GetDessertAsync(int id)
        {
            return await context.Desserts.FindAsync(id);
        }
        public void UpdateAsync(Dessert newDessert)
        {
            context.Desserts.First(d => d.Id == newDessert.Id).Name = newDessert.Name;
            context.Desserts.First(d => d.Id == newDessert.Id).Description = newDessert.Description;
            context.Desserts.First(d => d.Id == newDessert.Id).Price = newDessert.Price;
            context.Desserts.First(d => d.Id == newDessert.Id).IsFrozen = newDessert.IsFrozen;
            context.Desserts.First(d => d.Id == newDessert.Id).Millimeter = newDessert.Millimeter;
            context.SaveChangesAsync();
        }
    }
}
