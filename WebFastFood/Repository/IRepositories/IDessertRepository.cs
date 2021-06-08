using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    interface IDessertRepository
    {
        public Task<List<Dessert>> GetDessertsAsync();
        public Task<Dessert> GetDessertAsync(int id);
        public void CreateAsync(Dessert newDessert);
        public void DeleteAsync(Dessert dessert);
        public void UpdateAsync(Dessert newDessert);
    }
}
