using System;
using System.Collections.Generic;

namespace MVCApi.Domain.Entites
{
    public class Customer : BaseEntity, IDomainUser
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public List<Address> Addresses { get; private set; }
        public ContactInfo ContactInfo { get; private set; }

        private Customer()
        {
            Addresses = new List<Address>();
        }

        protected Customer(string firstName, string lastName, DateTime dateOfBirth, Address address, ContactInfo contactInfo)
            : base()
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Addresses = new List<Address>();
            Addresses.Add(address);
            ContactInfo = contactInfo;
        }

        public static Customer Create(string firstName, string lastName, DateTime dateOfBirth, Address address, ContactInfo contactInfo)
        {
            // TODO: Business logic checks
            return new Customer(firstName, lastName, dateOfBirth, address, contactInfo);
        }

        public void ChangeName(string name)
        {

        }
    }
}