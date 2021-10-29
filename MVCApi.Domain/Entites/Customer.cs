using System;

namespace MVCApi.Domain.Entites
{
    public class Customer : BaseEntity, IDomainUser
    {
        public Guid ApplicationUserId { get; private set; }
        public IApplicationUser ApplicationUser { get; private set; }

        private Customer()
        {

        }

        protected Customer(IApplicationUser user)
            : base()
        {
            ApplicationUserId = user.Id;
            ApplicationUser = user;
        }   

        public static Customer Create(IApplicationUser user)
        {
            return new Customer(user);
        }

        public void ChangeName(string name) {
            
        }
    }
}