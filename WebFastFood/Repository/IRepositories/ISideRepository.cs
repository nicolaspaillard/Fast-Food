using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface ISideRepository
    {
        public Task<List<Side>> GetSidesAsync();
        public Task<Side> GetSideAsync(int id);
        public Task<int> CreateAsync(Side newSide);
        public Task<int> DeleteAsync(Side side);
        public Task<int> UpdateAsync(Side newSide);
        public Task<bool> SideExistsAsync(int id);
    }
}
