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

namespace RunTeam.Application.Features.OrderHeads.Commands.Create
{
    public class CreateOrderHeadCommand : IRequest<Response<OrderHead>>
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
        public int Status { get; set; }
        public bool TaxAble { get; set; }
        public int TaxRate { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FreightCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetTotalAmount { get; set; }
        public string Remarks { get; set; }
        public int PaymentType { get; set; }
        public int PaymentId { get; set; }
        public int PaymentStatusCode { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipToContact { get; set; }
        public string ShipToContactPhone { get; set; }
    }

    public class CreateOrderHeadCommandHandler : IRequestHandler<CreateOrderHeadCommand, Response<OrderHead>>
    {
        private readonly IOrderHeadRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public CreateOrderHeadCommandHandler(IOrderHeadRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<OrderHead>> Handle(CreateOrderHeadCommand request, CancellationToken cancellationToken)
        {
            var _head = _mapper.Map<OrderHead>(request);

            //Insert personal detail to database.
            var _lastId = await _repository.GetLastIdAsync();
            _head.OrderNumber = _lastId.ToString("D6");
            var result = await _repository.AddAsync(_head);

            return new Response<OrderHead>(result);
        }
    }
}
