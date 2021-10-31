using MVCApi.Domain.Enums;

namespace MVCApi.Application.Dto
{
    public class OrderDto
    {
        public CustomerDto Customer { get; set; }
        public ShoppingCartDto ShoppingCart { get; set; }
        public OrderState OrderState { get; set; }
    }
}