using Dal;
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
        public void AddBeverage(Beverage beverage)
        {
            context.Beverages.Add(beverage);
        }

        //public void AddBurger(Burger burger)
        //{
        //    context.Burgers.Add(burger);
        //}

        public void AddDessert(Dessert dessert)
        {
            context.Desserts.Add(dessert);
        }

        public void AddMenu(Menu menu)
        {
            context.Menus.Add(menu);
        }

        public void AddSide(Side side)
        {
            context.Sides.Add(side);
        }

        public void DeleteBeverage(Beverage beverage)
        {
            context.Beverages.Remove(beverage);
        }

        //public void DeleteBurger(Burger burger)
        //{
        //    context.Burgers.Remove(burger);
        //}

        public void DeleteDessert(Dessert dessert)
        {
            context.Desserts.Remove(dessert);
        }

        public void DeleteMenu(Menu menu)
        {
            context.Menus.Remove(menu);
        }

        public void DeleteSide(Side side)
        {
            context.Sides.Remove(side);
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
            return context.Menus;
        }

        public IQueryable<Side> GetSides()
        {
            return context.Sides;
        }
    }
}
