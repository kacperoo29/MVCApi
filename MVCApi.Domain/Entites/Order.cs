using MVCApi.Domain.Enums;
using MVCApi.Domain.Exceptions;

namespace MVCApi.Domain.Entites
{
    public class Order : BaseEntity
    {
        protected Order()
        {
        }

        protected Order(Customer customer, ShoppingCart shoppingCart, Address address, ContactInfo contactInfo)
        {
            Customer = customer;
            ShoppingCart = shoppingCart;
            OrderState = OrderState.New;
            Address = address;
            ContactInfo = contactInfo;
        }

        public virtual Customer Customer { get; private set; }
        public virtual ShoppingCart ShoppingCart { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual ContactInfo ContactInfo { get; private set; }
        public OrderState OrderState { get; private set; }

        public static Order Create(Customer customer, ShoppingCart shoppingCart, Address address, ContactInfo contactInfo)
        {
            if (shoppingCart.Products.Count < 1)
                throw new EmptyCartException(shoppingCart.Id);

            shoppingCart.Lock();

            return new Order(customer, shoppingCart, address, contactInfo);
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