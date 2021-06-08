using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Repository.IRepositories
{
    public interface IBurgerRepository
    {
        public IQueryable<Burger> GetBurgers();
        public void AddBurger(Burger burger);
        public void DeleteBurger(int id);
        public Burger GetBurger(int id);
        public void EditBurger(Burger burger);
    }
}
