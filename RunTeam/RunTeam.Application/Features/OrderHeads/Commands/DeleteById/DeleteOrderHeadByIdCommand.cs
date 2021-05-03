using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.OrderHeads.Commands.DeleteById
{
    public class DeleteOrderHeadByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteOrderHeadByIdCommandHandler : IRequestHandler<DeleteOrderHeadByIdCommand, Response<int>>
        {
            private readonly IOrderHeadRepositoryAsync _repository;
            public DeleteOrderHeadByIdCommandHandler(IOrderHeadRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<int>> Handle(DeleteOrderHeadByIdCommand command, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(command.Id);
                if (_contact == null) throw new ApiException($"Order Not Found.");
                await _repository.DeleteAsync(_contact);
                return new Response<int>(_contact.Id);
            }
        }
    }
}
