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

namespace RunTeam.Application.Features.OrderHeads.Commands.Update
{
    public class UpdateOrderHeadCommand : IRequest<Response<OrderHead>>
    {
        public int Id { get; set; }
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

        public class UpdateOrderHeadCommandHandler : IRequestHandler<UpdateOrderHeadCommand, Response<OrderHead>>
        {
            private readonly IOrderHeadRepositoryAsync _repository;
            public UpdateOrderHeadCommandHandler(IOrderHeadRepositoryAsync repository)
            {
                _repository = repository;
            }

            public async Task<Response<OrderHead>> Handle(UpdateOrderHeadCommand command, CancellationToken cancellationToken)
            {
                var _orderHead = await _repository.GetByIdAsync(command.Id);

                if (_orderHead == null)
                {
                    throw new ApiException($"Order Not Found.");
                }
                else
                {
                    _orderHead.OrderDate = command.OrderDate;
                    _orderHead.UserId = command.UserId;
                    _orderHead.EventId = command.EventId;
                    _orderHead.Status = command.Status;
                    _orderHead.TaxAble = command.TaxAble;
                    _orderHead.TaxRate = command.TaxRate;
                    _orderHead.DiscountAmount = command.DiscountAmount;
                    _orderHead.FreightCharge = command.FreightCharge;
                    _orderHead.TotalAmount = command.TotalAmount;
                    _orderHead.NetTotalAmount = command.NetTotalAmount;
                    _orderHead.Remarks = command.Remarks;
                    _orderHead.PaymentType = command.PaymentType;
                    _orderHead.PaymentId = command.PaymentId;
                    _orderHead.PaymentStatusCode = command.PaymentStatusCode;
                    _orderHead.ShipToAddress = command.ShipToAddress;
                    _orderHead.ShipToContact = command.ShipToContact;
                    _orderHead.ShipToContactPhone = command.ShipToContactPhone;

                    await _repository.UpdateAsync(_orderHead);
                    return new Response<OrderHead>(_orderHead);
                }
            }
        }
    }
}
