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
        public void CreateAsync(Beverage beverage)
        {
            context.Beverages.Add(beverage);
            context.SaveChangesAsync();
        }
        public void CreateAsync(Burger burger)
        {
            context.Burgers.Add(burger);
            context.SaveChangesAsync();
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

        public void DeleteAsync(Beverage beverage)
        {
            context.Beverages.Remove(beverage);
            context.SaveChangesAsync();
        }
        public void DeleteAsync(Burger burger)
        {
            context.Burgers.Remove(burger);
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

        public async Task<List<Beverage>> GetBeveragesAsync()
        {
            return await context.Beverages.ToListAsync();
        }

        public async Task<List<Burger>> GetBurgersAsync()
        {
            return await context.Burgers.ToListAsync();
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

        public async Task<Beverage> GetBeverageAsync(int id)
        {
            return await context.Beverages.FindAsync(id);
        }

        public async Task<Burger> GetBurgerAsync(int id)
        {
            return await context.Burgers.FindAsync(id);
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

        public void UpdateAsync(Beverage newBeverage)
        {
            context.Beverages.First(b => b.Id == newBeverage.Id).Name = newBeverage.Name;
            context.Beverages.First(b => b.Id == newBeverage.Id).Description = newBeverage.Description;
            context.Beverages.First(b => b.Id == newBeverage.Id).Price = newBeverage.Price;
            context.Beverages.First(b => b.Id == newBeverage.Id).IsCarbonated = newBeverage.IsCarbonated;
            context.Beverages.First(b => b.Id == newBeverage.Id).Millimeter = newBeverage.Millimeter;
            context.SaveChangesAsync();
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
