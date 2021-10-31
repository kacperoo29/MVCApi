using System;
using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Customer : BaseEntity, IDomainUser
    {
        protected Customer()
        {
        }

        protected Customer(string firstName, string lastName, DateTime dateOfBirth, Address address,
            ContactInfo contactInfo)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Addresses = new List<Address>();
            Addresses.Add(address);
            ContactInfos = new List<ContactInfo>();
            ContactInfos.Add(contactInfo);
        }

        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public virtual ICollection<Address> Addresses { get; }
        public virtual ICollection<ContactInfo> ContactInfos { get; }

        public static Customer Create(string firstName, string lastName, DateTime dateOfBirth, Address address,
            ContactInfo contactInfo)
        {
            // TODO: Business logic checks
            return new Customer(firstName, lastName, dateOfBirth, address, contactInfo);
        }
    }
}