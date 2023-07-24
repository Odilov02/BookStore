using Domain.Common;

namespace Domain.Entities
{
    public class Basket : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
