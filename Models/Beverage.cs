using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Beverage : Product
    {
        public double Millimeter { get; set; }
        public bool IsCarbonated { get; set; }
    }
}