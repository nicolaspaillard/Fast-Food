using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface IFastFoodRepository
    {
        public Task<List<Beverage>> GetBeveragesAsync();
        public Task<Beverage> GetBeverageAsync(int id);
        public void CreateAsync(Beverage newBeverage);
        public void DeleteAsync(Beverage beverage);
        public void UpdateAsync(Beverage newBeverage);
        public Task<List<Burger>> GetBurgersAsync();
        public Task<Burger> GetBurgerAsync(int id);
        public void CreateAsync(Burger newBurger);
        public void DeleteAsync(Burger burger);
        public void UpdateAsync(Burger newBurger);
        public Task<List<Dessert>> GetDessertsAsync();
        public Task<Dessert> GetDessertAsync(int id);
        public void CreateAsync(Dessert newDessert);
        public void DeleteAsync(Dessert dessert);
        public void UpdateAsync(Dessert newDessert);
        public Task<List<Side>> GetSidesAsync();
        public Task<Side> GetSideAsync(int id);
        public void CreateAsync(Side newSide);
        public void DeleteAsync(Side side);
        public void UpdateAsync(Side newSide);
        public Task<List<Menu>> GetMenusAsync();
        public Task<Menu> GetMenuAsync(int id);
        public void CreateAsync(Menu newMenu);
        public void DeleteAsync(Menu menu);
        public void UpdateAsync(Menu newMenu);
    }
}
