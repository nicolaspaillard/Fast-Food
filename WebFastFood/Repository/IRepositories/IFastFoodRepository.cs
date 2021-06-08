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
        public Beverage GetBeverage(int id);
        public void Create(Beverage newBeverage);
        public void Delete(Beverage beverage);
        public void Update(Beverage newBeverage);
        public IQueryable<Burger> GetBurgers();
        public Burger GetBurger(int id);
        public void Create(Burger newBurger);
        public void Delete(Burger burger);
        public void Update(Burger newBurger);
        public IQueryable<Dessert> GetDesserts();
        public Dessert GetDessert(int id);
        public void Create(Dessert newDessert);
        public void Delete(Dessert dessert);
        public void Update(Dessert newDessert);
        public IQueryable<Side> GetSides();
        public Side GetSide(int id);
        public void Create(Side newSide);
        public void Delete(Side side);
        public void Update(Side newSide);
        public IQueryable<Menu> GetMenus();
        public Menu GetMenu(int id);
        public void Create(Menu newMenu);
        public void Delete(Menu menu);
        public void Update(Menu newMenu);
    }
}
