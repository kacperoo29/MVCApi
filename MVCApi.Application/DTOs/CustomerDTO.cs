using System;
using System.Collections.Generic;

namespace MVCApi.Application.DTOs
{
    public class CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<AddressDTO> Addresses { get; set; }
        public ICollection<ContactInfoDTO> ContactInfos { get; set; }
    }
}