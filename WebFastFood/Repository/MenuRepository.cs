﻿using Dal;
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
        public void CreateAsync(Menu menu)
        {
            context.Menus.Add(menu);
            context.SaveChangesAsync();
        }
        public void DeleteAsync(Menu menu)
        {
            context.Menus.Remove(menu);
            context.SaveChangesAsync();
        }
        public async Task<List<Menu>> GetMenusAsync()
        {
            return await context.Menus.Include(m => m.Burger).Include(m => m.Side).Include(m => m.Beverage).Include(m => m.Dessert).ToListAsync();
        }
        public async Task<Side> GetSideAsync(int id)
        {
            return await context.Sides.FindAsync(id);
        }
        public async Task<Menu> GetMenuAsync(int id)
        {
            return await context.Menus.FindAsync(id);
        }
        public void UpdateAsync(Menu newMenu)
        {
            context.Menus.First(m => m.Id == newMenu.Id).Name = newMenu.Name;
            context.Menus.First(m => m.Id == newMenu.Id).Description = newMenu.Description;
            context.Menus.First(m => m.Id == newMenu.Id).Price = newMenu.Price;
            context.Menus.First(m => m.Id == newMenu.Id).Burger = newMenu.Burger;
            context.Menus.First(m => m.Id == newMenu.Id).Side = newMenu.Side;
            context.Menus.First(m => m.Id == newMenu.Id).Beverage = newMenu.Beverage;
            context.Menus.First(m => m.Id == newMenu.Id).Dessert = newMenu.Dessert;
            context.SaveChangesAsync();
        }
    }
}
