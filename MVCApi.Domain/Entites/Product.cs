using System.Collections.Generic;
using System.Dynamic;

namespace MVCApi.Domain.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public List<ShoppingCart> Carts { get; private set; }

        private Product() { }
        
    }
}