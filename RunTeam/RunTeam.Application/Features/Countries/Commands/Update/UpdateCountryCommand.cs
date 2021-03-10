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

namespace RunTeam.Application.Features.Countries.Commands.Update
{
    public class UpdateCountryCommand : IRequest<Response<Country>>
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Response<Country>>
        {
            private readonly ICountryRepositoryAsync _repository;
            public UpdateCountryCommandHandler(ICountryRepositoryAsync repository)
            {
                _repository = repository;
            }

            public async Task<Response<Country>> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
            {
                var _country = await _repository.GetByIdAsync(command.Id);

                if (_country == null)
                {
                    throw new ApiException($"Country Not Found.");
                }
                else
                {
                    _country.CountryCode = command.CountryCode;
                    _country.CountryName = command.CountryName;

                    await _repository.UpdateAsync(_country);
                    return new Response<Country>(_country);
                }
            }
        }
    }
}
