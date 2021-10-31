using System;

namespace MVCApi.Application.Dto
{
    public class ContactInfoDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}