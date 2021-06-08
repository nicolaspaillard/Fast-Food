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
        public void AddBeverage(Beverage newBeverage);
        public void DeleteBeverage(Beverage beverage);
        public void EditBeverage(int id, Beverage newBeverage);
        public IQueryable<Burger> GetBurgers();
        public void AddBurger(Burger newBurger);
        public void DeleteBurger(Burger burger);
        public void EditBurger(int id, Burger newBurger);
        public IQueryable<Dessert> GetDesserts();
        public void AddDessert(Dessert newDessert);
        public void DeleteDessert(Dessert dessert);
        public void EditDessert(int id, Dessert newDessert);
        public IQueryable<Side> GetSides();
        public void AddSide(Side newSide);
        public void DeleteSide(Side side);
        public void EditSide(int id, Side newSide);
        public IQueryable<Menu> GetMenus();
        public void AddMenu(Menu newMenu);
        public void DeleteMenu(Menu menu);
        public void EditMenu(int id, Menu newMenu);
    }
}
