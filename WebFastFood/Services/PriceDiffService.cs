using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Repository.IRepositories;

namespace WebFastFood.Services
{
    public class PriceDiffService
    {
        private IMenuRepository _menus;
        private IBeverageRepository _beverages;
        private IBurgerRepository _burgers;
        private IDessertRepository _desserts;
        private ISideRepository _sides;

        public PriceDiffService(IMenuRepository repository, IBeverageRepository beverages, IBurgerRepository burgers, ISideRepository sides, IDessertRepository desserts)
        {
            _menus = repository;
            _beverages = beverages;
            _burgers = burgers;
            _desserts = desserts;
            _sides = sides;
        }

        public async Task<decimal> PriceDiff(Menu menu)
        {
            var beveragePrice = (await _beverages.GetBeverageAsync(menu.Beverage.Id)).Price;
            decimal dessertPrice = 0;
            if (menu.Dessert != null)
            {
                dessertPrice = (await _desserts.GetDessertAsync(menu.Dessert.Id)).Price;
            }            
            var burgerPrice = (await _burgers.GetBurgerAsync(menu.Burger.Id)).Price;
            var sidePrice = (await _sides.GetSideAsync(menu.Side.Id)).Price;

            return beveragePrice + dessertPrice + burgerPrice + sidePrice - menu.Price;
        }


    }
}
