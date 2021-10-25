using MVCApi.Domain.Enums;

namespace MVCApi.Domain.Entites
{
    public class Order : BaseEntity
    {
        public OrderState OrderState { get; private set; }


    }
}