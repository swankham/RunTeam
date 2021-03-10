using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.PersonalDetails.Commands.DeleteById
{
    public class DeletePersonalDetailByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeletePersonalDetailByIdCommandHandler : IRequestHandler<DeletePersonalDetailByIdCommand, Response<int>>
        {
            private readonly IPersonalDetailRepositoryAsync _repository;
            public DeletePersonalDetailByIdCommandHandler(IPersonalDetailRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<int>> Handle(DeletePersonalDetailByIdCommand command, CancellationToken cancellationToken)
            {
                var _personal = await _repository.GetByIdAsync(command.Id);
                if (_personal == null) throw new ApiException($"Personal detail Not Found.");
                await _repository.DeleteAsync(_personal);
                return new Response<int>(_personal.Id);
            }
        }
    }
}
