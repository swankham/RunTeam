using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.OrderLines.Commands.DeleteById
{
    public class DeleteOrderLineByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteOrderLineByIdCommandHandler : IRequestHandler<DeleteOrderLineByIdCommand, Response<int>>
        {
            private readonly IOrderLineRepositoryAsync _repository;
            public DeleteOrderLineByIdCommandHandler(IOrderLineRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<int>> Handle(DeleteOrderLineByIdCommand command, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(command.Id);
                if (_contact == null) throw new ApiException($"Order line not found.");
                await _repository.DeleteAsync(_contact);
                return new Response<int>(_contact.Id);
            }
        }
    }
}
