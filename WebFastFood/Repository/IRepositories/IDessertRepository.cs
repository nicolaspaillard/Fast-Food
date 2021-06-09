using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface IDessertRepository
    {
        public Task<List<Dessert>> GetDessertsAsync();
        public Task<Dessert> GetDessertAsync(int id);
        public Task<int> CreateAsync(Dessert newDessert);
        public Task<int> DeleteAsync(Dessert dessert);
        public Task<int> UpdateAsync(Dessert newDessert);
        public Task<bool> DessertExistsAsync(int id);
    }
}
