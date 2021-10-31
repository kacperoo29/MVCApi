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

        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string StreetNumber { get; }
        public string PostCode { get; }
        public virtual Customer Customer { get; private set; }

        public static Address Create(string country, string city, string street, string streetNumber, string postCode)
        {
            return new Address(country, city, street, streetNumber, postCode);
        }
    }
}