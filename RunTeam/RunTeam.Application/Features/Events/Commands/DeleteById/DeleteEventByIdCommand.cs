using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Events.Commands.DeleteById
{
    public class DeleteEventByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteEventByIdCommandHandler : IRequestHandler<DeleteEventByIdCommand, Response<int>>
        {
            private readonly IEventRepositoryAsync _repository;
            public DeleteEventByIdCommandHandler(IEventRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<int>> Handle(DeleteEventByIdCommand command, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(command.Id);
                if (_contact == null) throw new ApiException($"Event Not Found.");
                await _repository.DeleteAsync(_contact);
                return new Response<int>(_contact.Id);
            }
        }
    }
}
