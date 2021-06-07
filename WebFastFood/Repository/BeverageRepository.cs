using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Repository.IRepositories;

namespace WebFastFood.Repository
{
    public class BeverageRepository : IBeverageRepository
    {
        private FastFoodContext context;

        public BeverageRepository()
        {

        }

        public BeverageRepository(FastFoodContext context) {
            this.context = context;
        }

        public void AddBeverage(Beverage beverage)
        {
            context.Beverages.Add(beverage);
        }

        public void DeleteBeverage(Beverage beverage)
        {
            context.Beverages.Remove(beverage);
        }

        public IQueryable<Beverage> GetBeverages()
        {
            return context.Beverages;
        }
    }
}
