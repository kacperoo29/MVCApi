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

        public void ChangeCountry(string country)
        {
            Country = country;
        }

        public void ChangeCity(string city)
        {
            City = city;
        }

        public void ChangeStreet(string street)
        {
            Street = street;
        }

        public void ChangeStreetNumber(string streetNumber)
        {
            StreetNumber = streetNumber;
        }

        public void ChangePostCode(string postCode)
        {
            PostCode = postCode;
        }

    }
}