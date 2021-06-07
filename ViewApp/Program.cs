using Dal;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ViewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FastFoodContext())
            {
                context.Initialize(true);
                //on s'amuse
            }
        }

        }
}
