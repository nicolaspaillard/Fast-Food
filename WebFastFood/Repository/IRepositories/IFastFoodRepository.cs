using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface IFastFoodRepository
    {
        public IQueryable<Beverage> GetBeverages();
        public void AddBeverage(Beverage beverage);
        public void DeleteBeverage(Beverage beverage);
       // public IQueryable<Burger> GetBurgers();
        //public void AddBurger(Burger burger);
        //public void DeleteBurger(Burger burger);
        public IQueryable<Dessert> GetDesserts();
        public void AddDessert(Dessert dessert);
        public void DeleteDessert(Dessert dessert);
        public IQueryable<Side> GetSides();
        public void AddSide(Side side);
        public void DeleteSide(Side side);
        public IQueryable<Menu> GetMenus();
        public void AddMenu(Menu menu);
        public void DeleteMenu(Menu menu);
    }
}
