using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface IBeverageRepository 
    {
        public IQueryable<Beverage> GetBeverages();
        public void AddBeverage(Beverage beverage);
        public void DeleteBeverage(Beverage beverage);

    }
}
