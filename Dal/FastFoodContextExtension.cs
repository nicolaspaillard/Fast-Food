using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class FastFoodContextExtension
    {       
        public static void Initialize(this FastFoodContext context, bool dropAlways = false)
        {
            //To drop database or not
            if (dropAlways)
                context.Database.EnsureDeleted();

            context.Database.EnsureCreated();
            
            //if db has been already seeded
            if (context.Products.Any())
                return;

            context.Beverages.AddRange(
                new List<Beverage>()
                {
                    new Beverage()
                    {
                        Description = "Coca pas light",
                        IsCarbonated= true,
                        Millimeter= 20.00,
                        Name="Coca",
                        Price= 3.50M
                    },
                    new Beverage()
                    {
                        Description = "jus d'orange pas light",
                        IsCarbonated= false,
                        Millimeter= 35.00,
                        Name="Jus d'orange",
                        Price= 1.80M
                    },
                });

            context.SaveChanges();
        }
    }
}
