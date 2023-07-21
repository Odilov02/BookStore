using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Basket
    {
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
