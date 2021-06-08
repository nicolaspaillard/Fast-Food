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

        public void DeleteBurger(Burger burger)
        {
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

        public void EditBurger(int id, Burger burger)
        {
            var burgerBDD = GetBurger(id);
            burgerBDD.BeefWeight = burger.BeefWeight;
            burgerBDD.Description = burger.Description;
            burgerBDD.Name = burger.Name;
            burgerBDD.Price = burger.Price;
            burgerBDD.Weight = burger.Weight;
        }
    }
}
