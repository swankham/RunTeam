using AutoMapper;
using MediatR;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.OrderLines.Commands.Create
{
    public class CreateOrderLineCommand : IRequest<Response<OrderLine>>
    {
        public int HeaderId { get; set; }
        public int LineNumber { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string UOM { get; set; }
        public int TaxRate { get; set; }
        public decimal Amount { get; set; }
        public DateTime PromiseDate { get; set; }
        public int Status { get; set; }
    }

    public class CreateOrderLineCommandHandler : IRequestHandler<CreateOrderLineCommand, Response<OrderLine>>
    {
        private readonly IOrderLineRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public CreateOrderLineCommandHandler(IOrderLineRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<OrderLine>> Handle(CreateOrderLineCommand request, CancellationToken cancellationToken)
        {
            var _head = _mapper.Map<OrderLine>(request);

            //Insert personal detail to database.
            var result = await _repository.AddAsync(_head);

            return new Response<OrderLine>(result);
        }
    }
}
