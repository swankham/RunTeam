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

namespace RunTeam.Application.Features.Countries.Commands.Create
{
    public class CreateCountryCommand : IRequest<Response<Country>>
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Response<Country>>
    {
        private readonly ICountryRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(ICountryRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Country>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var _country = _mapper.Map<Country>(request);

            //Insert personal detail to database.
            var result = await _repository.AddAsync(_country);

            return new Response<Country>(result);
        }
    }
}
