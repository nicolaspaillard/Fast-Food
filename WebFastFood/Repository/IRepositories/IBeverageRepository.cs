using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface IBeverageRepository 
    {
        public Task<List<Beverage>> GetBeveragesAsync();
        public Task<Beverage> GetBeverageAsync(int id);
        public void CreateAsync(Beverage newBeverage);
        public void DeleteAsync(Beverage beverage);
        public void UpdateAsync(Beverage newBeverage);
    }
}
