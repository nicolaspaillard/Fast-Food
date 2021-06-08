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
        public void CreateAsync(Burger newBurger);
        public void DeleteAsync(Burger burger);
        public void UpdateAsync(Burger newBurger);
    }
}
