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

        public void AddBurger(Burger burger)
        {
            context.Burgers.Add(burger);
        }

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
            throw new NotImplementedException();
        }

        public void DeleteBeverage(Beverage beverage)
        {
            throw new NotImplementedException();
        }

        public void DeleteBurger(Burger burger)
        {
            throw new NotImplementedException();
        }

        public void DeleteDessert(Dessert dessert)
        {
            throw new NotImplementedException();
        }

        public void DeleteMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void DeleteSide(Side side)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Beverage> GetBeverages()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Burger> GetBurgers()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Dessert> GetDesserts()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Menu> GetMenus()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Side> GetSides()
        {
            throw new NotImplementedException();
        }
    }
}
