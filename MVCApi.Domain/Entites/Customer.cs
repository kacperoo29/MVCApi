namespace MVCApi.Domain.Entites
{
    public class Customer : BaseEntity
    {
        protected Customer()
            : base()
        {

        }

        public static Customer Create()
        {
            return new Customer();
        }
    }
}