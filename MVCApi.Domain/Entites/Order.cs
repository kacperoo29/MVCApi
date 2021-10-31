using MVCApi.Domain.Enums;

namespace MVCApi.Domain.Entites
{
    public class Order : BaseEntity
    {
        private Order()
        {
        }

        protected Order(Customer customer, ShoppingCart shoppingCart)
        {
            Customer = customer;
            ShoppingCart = shoppingCart;
            OrderState = OrderState.New;
        }

        public virtual Customer Customer { get; }
        public virtual ShoppingCart ShoppingCart { get; }
        public OrderState OrderState { get; }

        public static Order Create(Customer customer, ShoppingCart shoppingCart)
        {
            return new Order(customer, shoppingCart);
        }
    }
}