using Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Repository.IRepositories;

namespace WebFastFood.Repository
{
    public class FastFoodRepository : IFastFoodRepository
    {
        private FastFoodContext context;
        public FastFoodRepository(FastFoodContext context)
        {
            this.context = context;
        }

        public void CreateAsync(Dessert dessert)
        {
            context.Desserts.Add(dessert);
            context.SaveChangesAsync();
        }

        public void CreateAsync(Menu menu)
        {
            context.Menus.Add(menu);
            context.SaveChangesAsync();
        }

        public void CreateAsync(Side side)
        {
            context.Sides.Add(side);
            context.SaveChangesAsync();
        }



        public void DeleteAsync(Dessert dessert)
        {
            context.Desserts.Remove(dessert);
            context.SaveChangesAsync();
        }

        public void DeleteAsync(Menu menu)
        {
            context.Menus.Remove(menu);
            context.SaveChangesAsync();
        }

        public void DeleteAsync(Side side)
        {
            context.Sides.Remove(side);
            context.SaveChangesAsync();
        }




        public async Task<List<Dessert>> GetDessertsAsync()
        {
            return await context.Desserts.ToListAsync();
        }
        public async Task<List<Menu>> GetMenusAsync()
        {
            return await context.Menus.Include(m => m.Burger).Include(m => m.Side).Include(m => m.Beverage).Include(m => m.Dessert).ToListAsync();
        }

        public async Task<List<Side>> GetSidesAsync()
        {
            return await context.Sides.ToListAsync();
        }




        public async Task<Dessert> GetDessertAsync(int id)
        {
            return await context.Desserts.FindAsync(id);
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




        public void UpdateAsync(Dessert newDessert)
        {
            context.Desserts.First(d => d.Id == newDessert.Id).Name = newDessert.Name;
            context.Desserts.First(d => d.Id == newDessert.Id).Description = newDessert.Description;
            context.Desserts.First(d => d.Id == newDessert.Id).Price = newDessert.Price;
            context.Desserts.First(d => d.Id == newDessert.Id).IsFrozen = newDessert.IsFrozen;
            context.Desserts.First(d => d.Id == newDessert.Id).Millimeter = newDessert.Millimeter;
            context.SaveChangesAsync();
        }

        public void UpdateAsync(Side newSide)
        {
            context.Sides.First(s => s.Id == newSide.Id).Name = newSide.Name;
            context.Sides.First(s => s.Id == newSide.Id).Description = newSide.Description;
            context.Sides.First(s => s.Id == newSide.Id).Price = newSide.Price;
            context.Sides.First(s => s.Id == newSide.Id).Weight = newSide.Weight;
            context.Sides.First(s => s.Id == newSide.Id).SaltWeight = newSide.SaltWeight;
            context.SaveChangesAsync();
        }


    }
}
