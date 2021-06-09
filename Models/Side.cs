using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Side : Product
    {
        [Column("SideWeight")]
        public int Weight { get; set; }
        public int SaltWeight { get; set; }
    }
}