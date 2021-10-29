using System;

namespace MVCApi.Domain.Entites
{
    public class Customer : BaseEntity, IDomainUser
    {
        public IApplicationUser ApplicationUser { get; private set; }

        protected Customer()
            : base()
        {
            
        }

        public static Customer Create()
        {
            return new Customer();
        }

        public void ChangeName(string name)
        {

        }

        public void SetReference(IApplicationUser user) 
        {
            ApplicationUser = user;
        }
    }
}