using System;

namespace MVCApi.Application.Dto
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public Guid DomainUserId { get; set; }
    }
}