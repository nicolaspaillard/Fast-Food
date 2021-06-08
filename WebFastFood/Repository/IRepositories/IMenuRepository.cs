using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface IMenuRepository
    {
        public Task<List<Menu>> GetMenusAsync();
        public Task<Menu> GetMenuAsync(int id);
        public Task<int> CreateAsync(Menu newMenu);
        public Task<int> DeleteAsync(Menu menu);
        public Task<int> UpdateAsync(Menu newMenu);
    }
}
