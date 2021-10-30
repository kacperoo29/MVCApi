using MVCApi.Domain.Enums;

namespace MVCApi.Domain.Entites
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }
        public OrderState OrderState { get; private set; }

        private Order() { }

        protected Order(Customer customer, ShoppingCart shoppingCart)
        {
            Customer = customer;
            ShoppingCart = shoppingCart;
        }

        public static Order Create(Customer customer, ShoppingCart shoppingCart)
        {
            return new Order(customer, shoppingCart);
        }

    }
}