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
    public class SideRepository : ISideRepository
    {
        private FastFoodContext context;
        public SideRepository(FastFoodContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Side side)
        {
            context.Sides.Add(side);
            return await context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(Side side)
        {
            context.Sides.Remove(side);
            return await context.SaveChangesAsync();
        }
        public async Task<List<Side>> GetSidesAsync()
        {
            return await context.Sides.ToListAsync();
        }
        public async Task<Side> GetSideAsync(int id)
        {
            return await context.Sides.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> UpdateAsync(Side newSide)
        {
            context.Sides.First(s => s.Id == newSide.Id).Name = newSide.Name;
            context.Sides.First(s => s.Id == newSide.Id).Description = newSide.Description;
            context.Sides.First(s => s.Id == newSide.Id).Price = newSide.Price;
            context.Sides.First(s => s.Id == newSide.Id).Weight = newSide.Weight;
            context.Sides.First(s => s.Id == newSide.Id).SaltWeight = newSide.SaltWeight;
            return await context.SaveChangesAsync();
        }
        public async Task<bool> SideExistsAsync(int id)
        {
            return await context.Sides.AnyAsync(d => d.Id == id);
        }
    }
}
