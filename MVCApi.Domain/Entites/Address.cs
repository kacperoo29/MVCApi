namespace MVCApi.Domain.Entites
{
    public class Address : BaseEntity
    {
        protected Address(string country, string city, string street, string streetNumber, string postCode)
        {
            Country = country;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            PostCode = postCode;
        }

        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public string PostCode { get; private set; }
        public virtual Customer Customer { get; private set; }

        public static Address Create(string country, string city, string street, string streetNumber, string postCode)
        {
            return new Address(country, city, street, streetNumber, postCode);
        }

        public void Change(string country, string city, string street, string streetNumber, string postCode)
        {
            Country = country;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            PostCode = postCode;
        }


    }
}