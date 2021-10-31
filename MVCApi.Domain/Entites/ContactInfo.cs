namespace MVCApi.Domain.Entites
{
    public class ContactInfo : BaseEntity
    {
        protected ContactInfo(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Email { get; }
        public string PhoneNumber { get; }
        public virtual Customer Customer { get; private set; }

        public static ContactInfo Create(string email, string phoneNumber)
        {
            return new ContactInfo(email, phoneNumber);
        }
    }
}