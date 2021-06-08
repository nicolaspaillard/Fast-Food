using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    interface IMenuRepository
    {
        public Task<List<Menu>> GetMenusAsync();
        public Task<Menu> GetMenuAsync(int id);
        public void CreateAsync(Menu newMenu);
        public void DeleteAsync(Menu menu);
        public void UpdateAsync(Menu newMenu);
    }
}
