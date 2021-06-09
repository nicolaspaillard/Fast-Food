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
    public class MenuRepository : IMenuRepository
    {
        private FastFoodContext context;
        public MenuRepository(FastFoodContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Menu menu)
        {
            context.Menus.Add(menu);
            return await context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(Menu menu)
        {
            context.Menus.Remove(menu);
            return await context.SaveChangesAsync();
        }
        public async Task<List<Menu>> GetMenusAsync()
        {
            return await context.Menus.Include(m => m.Burger).Include(m => m.Side).Include(m => m.Beverage).Include(m => m.Dessert).ToListAsync();
        }
        public async Task<Menu> GetMenuAsync(int id)
        {
            return await context.Menus.Include(m => m.Burger).Include(m => m.Side).Include(m => m.Beverage).Include(m => m.Dessert).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> UpdateAsync(Menu newMenu)
        {
            context.Menus.First(m => m.Id == newMenu.Id).Name = newMenu.Name;
            context.Menus.First(m => m.Id == newMenu.Id).Description = newMenu.Description;
            context.Menus.First(m => m.Id == newMenu.Id).Price = newMenu.Price;
            context.Menus.First(m => m.Id == newMenu.Id).Burger = newMenu.Burger;
            context.Menus.First(m => m.Id == newMenu.Id).Side = newMenu.Side;
            context.Menus.First(m => m.Id == newMenu.Id).Beverage = newMenu.Beverage;
            context.Menus.First(m => m.Id == newMenu.Id).Dessert = newMenu.Dessert;
            return await context.SaveChangesAsync();
        }
    }
}
