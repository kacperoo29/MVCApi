using System;
using System.Threading;
using System.Threading.Tasks;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using MediatR;

namespace MVCApi.Application.Commands
{
    public class EditCustomer : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }

        public class Handler : IRequestHandler<EditCustomer, Guid>
        {
            private readonly IDomainRepository<Customer> _customerRepository;

            public Handler(IDomainRepository<Customer> customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<Guid> Handle(EditCustomer request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
                
                if (customer == null)
                {
                    return default;
                }
                else
                {
                    customer.ChangeFirstName(request.FirstName);
                    customer.ChangeLastName(request.LastName);
                    customer.ChangeDateOfBirth(request.DateOfBirth);

                    return await _customerRepository.EditAsync(customer);
                }
            }
        }
    }
}