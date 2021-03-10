using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Contacts.Commands.DeleteById
{
    public class DeleteContactByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteContactByIdCommandHandler : IRequestHandler<DeleteContactByIdCommand, Response<int>>
        {
            private readonly IContactAddressRepositoryAsync _repository;
            public DeleteContactByIdCommandHandler(IContactAddressRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<int>> Handle(DeleteContactByIdCommand command, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(command.Id);
                if (_contact == null) throw new ApiException($"Contact Address Not Found.");
                await _repository.DeleteAsync(_contact);
                return new Response<int>(_contact.Id);
            }
        }
    }
}
