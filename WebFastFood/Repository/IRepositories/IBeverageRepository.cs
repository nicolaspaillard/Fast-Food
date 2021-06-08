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
        public Task<int> CreateAsync(Beverage newBeverage);
        public Task<int> DeleteAsync(Beverage beverage);
        public Task<int> UpdateAsync(Beverage newBeverage);
    }
}
