using System;
using System.Collections.Generic;

namespace MVCApi.Application.Dto
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
        public ICollection<ContactInfoDto> ContactInfos { get; set; }
    }
}