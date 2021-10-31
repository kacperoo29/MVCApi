using MVCApi.Domain.Enums;

namespace MVCApi.Application.DTOs
{
    public class OrderDTO
    {
        public CustomerDTO Customer { get; set; }
        public ShoppingCartDTO ShoppingCart { get; set; }
        public OrderState OrderState { get; set; }
    }
}