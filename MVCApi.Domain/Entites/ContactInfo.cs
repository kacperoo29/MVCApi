using System;

namespace MVCApi.Domain.Entites
{
    public class ContactInfo : BaseEntity
    {
        public string Email { get; private set; }        
        public string PhoneNumber { get; private set; }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        protected ContactInfo(string email, string phoneNumber)
            : base()
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }
        
        public static ContactInfo Create(string email, string phoneNumber)
        {
            return new ContactInfo(email, phoneNumber);
        }

        public void LinkCustomer(Customer customer)
        {
            CustomerId = customer.Id;
            Customer = customer;
        }

    }
}