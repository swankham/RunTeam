using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.OrderLines.Commands.Update
{
    public class UpdateOrderLineCommand : IRequest<Response<OrderLine>>
    {
        public int Id { get; set; }
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

        public class UpdateOrderLineCommandHandler : IRequestHandler<UpdateOrderLineCommand, Response<OrderLine>>
        {
            private readonly IOrderLineRepositoryAsync _repository;
            public UpdateOrderLineCommandHandler(IOrderLineRepositoryAsync repository)
            {
                _repository = repository;
            }

            public async Task<Response<OrderLine>> Handle(UpdateOrderLineCommand command, CancellationToken cancellationToken)
            {
                var _orderLine = await _repository.GetByIdAsync(command.Id);

                if (_orderLine == null)
                {
                    throw new ApiException($"Order line not found.");
                }
                else
                {
                    _orderLine.PromiseDate = command.PromiseDate;
                    _orderLine.HeaderId = command.HeaderId;
                    _orderLine.Status = command.Status;

                    await _repository.UpdateAsync(_orderLine);
                    return new Response<OrderLine>(_orderLine);
                }
            }
        }
    }
}
