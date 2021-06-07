using Dal;
using Models;
using System;
using System.Collections.Generic;

namespace ViewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FastFoodContext())
            {
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
                    } ); 
                
            }
        }
    }
}
