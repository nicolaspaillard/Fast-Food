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
    public class FastFoodRepository : IFastFoodRepository
    {
        private FastFoodContext context;
        public FastFoodRepository(FastFoodContext context)
        {
            this.context = context;
        }
        public void Create(Beverage beverage)
        {
            context.Beverages.Add(beverage);
            context.SaveChanges();
        }

        public void AddBurger(Burger burger)
        {
            context.Burgers.Add(burger);
            context.SaveChanges();
        }

        public void Create(Dessert dessert)
        {
            context.Desserts.Add(dessert);
            context.SaveChanges();
        }

        public void Create(Menu menu)
        {
            context.Menus.Add(menu);
            context.SaveChanges();
        }

        public void Create(Side side)
        {
            context.Sides.Add(side);
            context.SaveChanges();
        }

        public void Delete(Beverage beverage)
        {
            context.Beverages.Remove(beverage);
            context.SaveChanges();
        }

        public void DeleteBurger(Burger burger)
        {
            context.Burgers.Remove(burger);
            context.SaveChanges();
        }

        public void Delete(Dessert dessert)
        {
            context.Desserts.Remove(dessert);
            context.SaveChanges();
        }

        public void Delete(Menu menu)
        {
            context.Menus.Remove(menu);
            context.SaveChanges();
        }

        public void Delete(Side side)
        {
            context.Sides.Remove(side);
            context.SaveChanges();
        }

        public IQueryable<Beverage> GetBeverages()
        {
            return context.Beverages;
        }

        //public IQueryable<Burger> GetBurgers()
        //{
        //    return context.Burgers;
        //}

        public IQueryable<Dessert> GetDesserts()
        {
            return context.Desserts;
        }

        public IQueryable<Menu> GetMenus()
        {
            return context.Menus.Include(m => m.Burger).Include(m => m.Side).Include(m => m.Beverage).Include(m => m.Dessert);
        }

        public IQueryable<Side> GetSides()
        {
            return context.Sides;
        }

        public Beverage GetBeverage(int id)
        {
            return context.Beverages.Find(id);
        }

        public Burger GetBurger(int id)
        {
            return context.Burgers.Find(id);
        }

        public Dessert GetDessert(int id)
        {
            return context.Desserts.Find(id);
        }

        public Side GetSide(int id)
        {
            return context.Sides.Find(id);
        }

        public Menu GetMenu(int id)
        {
            return context.Menus.Find(id);
        }
        public void Update(Menu newMenu)
        {
            context.Menus.First(m => m.Id == newMenu.Id).Name = newMenu.Name;
            context.Menus.First(m => m.Id == newMenu.Id).Description = newMenu.Description;
            context.Menus.First(m => m.Id == newMenu.Id).Price = newMenu.Price;
            context.Menus.First(m => m.Id == newMenu.Id).Burger = newMenu.Burger;
            context.Menus.First(m => m.Id == newMenu.Id).Side = newMenu.Side;
            context.Menus.First(m => m.Id == newMenu.Id).Beverage = newMenu.Beverage;
            context.Menus.First(m => m.Id == newMenu.Id).Dessert = newMenu.Dessert;
            context.SaveChanges();
        }

        public void Update(Beverage newBeverage)
        {
            context.Beverages.First(b => b.Id == newBeverage.Id).Name = newBeverage.Name;
            context.Beverages.First(b => b.Id == newBeverage.Id).Description = newBeverage.Description;
            context.Beverages.First(b => b.Id == newBeverage.Id).Price = newBeverage.Price;
            context.Beverages.First(b => b.Id == newBeverage.Id).IsCarbonated = newBeverage.IsCarbonated;
            context.Beverages.First(b => b.Id == newBeverage.Id).Millimeter = newBeverage.Millimeter;
            context.SaveChanges();
        }

        public void Update(Burger newBurger)
        {
            context.Burgers.First(b => b.Id == newBurger.Id).Name = newBurger.Name;
            context.Burgers.First(b => b.Id == newBurger.Id).Description = newBurger.Description;
            context.Burgers.First(b => b.Id == newBurger.Id).Price = newBurger.Price;
            context.Burgers.First(b => b.Id == newBurger.Id).Weight = newBurger.Weight;
            context.Burgers.First(b => b.Id == newBurger.Id).BeefWeight = newBurger.BeefWeight;
            context.SaveChanges();
        }

        public void Update(Dessert newDessert)
        {
            context.Desserts.First(d => d.Id == newDessert.Id).Name = newDessert.Name;
            context.Desserts.First(d => d.Id == newDessert.Id).Description = newDessert.Description;
            context.Desserts.First(d => d.Id == newDessert.Id).Price = newDessert.Price;
            context.Desserts.First(d => d.Id == newDessert.Id).IsFrozen = newDessert.IsFrozen;
            context.Desserts.First(d => d.Id == newDessert.Id).Millimeter = newDessert.Millimeter;
            context.SaveChanges();
        }

        public void Update(Side newSide)
        {
            context.Sides.First(s => s.Id == newSide.Id).Name = newSide.Name;
            context.Sides.First(s => s.Id == newSide.Id).Description = newSide.Description;
            context.Sides.First(s => s.Id == newSide.Id).Price = newSide.Price;
            context.Sides.First(s => s.Id == newSide.Id).Weight = newSide.Weight;
            context.Sides.First(s => s.Id == newSide.Id).SaltWeight = newSide.SaltWeight;
            context.SaveChanges();
        }
    }
}
