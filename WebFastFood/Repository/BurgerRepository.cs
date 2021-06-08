using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Repository.IRepositories;

namespace WebFastFood.Repository
{
    public class BurgerRepository : IBurgerRepository
    {
        private FastFoodContext context;
        public BurgerRepository(FastFoodContext context)
        {
            this.context = context;
        }

        public void AddBurger(Burger burger)
        {
            context.Burgers.Add(burger);
            context.SaveChanges();
        }

        public void DeleteBurger(int id)
        {
            var burger = context.Burgers.Find(id);
            context.Burgers.Remove(burger);
            context.SaveChanges();
        }

        public IQueryable<Burger> GetBurgers()
        {
            return context.Burgers;
        }

        public Burger GetBurger(int id)
        {
            return context.Burgers.FirstOrDefault(b => b.Id == id);
        }

        public void EditBurger(Burger burger)
        {
            context.Burgers.Update(burger);
            context.SaveChanges();
        }
    }
}
