using MVCApi.Domain.Enums;
using MVCApi.Domain.Exceptions;

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

        public virtual Customer Customer { get; private set; }
        public virtual ShoppingCart ShoppingCart { get; private set; }
        public OrderState OrderState { get; private set; }

        public static Order Create(Customer customer, ShoppingCart shoppingCart)
        {
            if(shoppingCart.Products.Count < 1)
                throw new EmptyCartException(shoppingCart.Id);

            return new Order(customer, shoppingCart);
        }

        public void Process()
        {
            if (OrderState != OrderState.New)
                throw new InvalidEntityStateException(typeof(Order), OrderState.ToString(), nameof(Process));

            OrderState = OrderState.InProgress;
        }

        public void Finish()
        {
            if (OrderState != OrderState.InProgress)
                throw new InvalidEntityStateException(typeof(Order), OrderState.ToString(), nameof(Process));

            OrderState = OrderState.Ended;
        }
    }
}