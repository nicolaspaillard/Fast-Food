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
        public void CreateAsync(Side newSide);
        public void DeleteAsync(Side side);
        public void UpdateAsync(Side newSide);
    }
}
