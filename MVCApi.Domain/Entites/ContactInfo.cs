namespace MVCApi.Domain.Entites
{
    public class ContactInfo : BaseEntity
    {
        protected ContactInfo(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public virtual Customer Customer { get; private set; }

        public static ContactInfo Create(string email, string phoneNumber)
        {
            return new ContactInfo(email, phoneNumber);
        }

        public void Change(string email, string phoneNumber){
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}