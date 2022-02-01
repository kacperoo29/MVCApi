using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using MVCApi.Domain.Enums;

namespace MVCApi.Application.Commands
{
    public class ChangeOrderState : IRequest<Guid>
    {
        public Guid OrderId { get; init; }
        public OrderState State { get; init; }

        public class Handler : IRequestHandler<ChangeOrderState, Guid>
        {
            private readonly IDomainRepository<Order> _repository;

            public Handler(IDomainRepository<Order> repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(ChangeOrderState request, CancellationToken cancellationToken)
            {
                var order = await _repository.GetByIdAsync(request.OrderId);

                order.ChangeState(request.State);

                return await _repository.EditAsync(order);
            }
        }
    }
}
