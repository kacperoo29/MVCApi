using System;
using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Customer : BaseEntity, IDomainUser
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public virtual ICollection<Address> Addresses { get; private set; }
        public virtual ICollection<ContactInfo> ContactInfos { get; private set; }

        protected Customer()
        {
            
        }

        protected Customer(string firstName, string lastName, DateTime dateOfBirth, Address address, ContactInfo contactInfo)
            : base()
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Addresses = new List<Address>();
            Addresses.Add(address);
            ContactInfos = new List<ContactInfo>();
            ContactInfos.Add(contactInfo);
        }

        public static Customer Create(string firstName, string lastName, DateTime dateOfBirth, Address address, ContactInfo contactInfo)
        {
            // TODO: Business logic checks
            return new Customer(firstName, lastName, dateOfBirth, address, contactInfo);
        }
    }
}