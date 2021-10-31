using System;
using System.Collections.Generic;
using MVCApi.Domain.Consts;
using MVCApi.Domain.Exceptions;

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

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public virtual ICollection<Address> Addresses { get; private set; }
        public virtual ICollection<ContactInfo> ContactInfos { get; private set; }

        public static Customer Create(string firstName, string lastName, DateTime dateOfBirth, Address address,
            ContactInfo contactInfo)
        {
            if (dateOfBirth.Date > DateTime.Now.Date.AddYears(-EShopConsts.MinCustomerAge))
                throw new CustomerTooYoungException();

            return new Customer(firstName, lastName, dateOfBirth.Date, address, contactInfo);
        }

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
        }

        public void AddContactInfo(ContactInfo contactInfo)
        {
            ContactInfos.Add(contactInfo);
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }
    }
}