namespace MVCApi.Domain.Entites
{
    public class Address : BaseEntity
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public string PostCode { get; private set; }

        protected Address(string country, string city, string street, string streetNumber, string postCode)
            : base()
        {
            Country = country;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            PostCode = postCode;
        }

        public static Address Create(string country, string city, string street, string streetNumber, string postCode)
        {
            return new Address(country, city, street, streetNumber, postCode);
        }
    }
}