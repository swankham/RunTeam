using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Countries.Commands.DeleteById
{
    public class DeleteCountryByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteCountryByIdCommandHandler : IRequestHandler<DeleteCountryByIdCommand, Response<int>>
        {
            private readonly ICountryRepositoryAsync _repository;
            public DeleteCountryByIdCommandHandler(ICountryRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<int>> Handle(DeleteCountryByIdCommand command, CancellationToken cancellationToken)
            {
                var _country = await _repository.GetByIdAsync(command.Id);
                if (_country == null) throw new ApiException($"Country Not Found.");
                await _repository.DeleteAsync(_country);
                return new Response<int>(_country.Id);
            }
        }
    }
}
