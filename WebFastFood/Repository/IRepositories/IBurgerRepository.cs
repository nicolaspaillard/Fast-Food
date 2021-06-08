using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface IBurgerRepository
    {
        public Task<List<Burger>> GetBurgersAsync();
        public Task<Burger> GetBurgerAsync(int id);
        public Task<int> CreateAsync(Burger newBurger);
        public Task<int> DeleteAsync(Burger burger);
        public Task<int> UpdateAsync(Burger newBurger);
    }
}
