using AutoMapper;
using MediatR;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Countries.Queries.GetAll
{
    public class GetAllCountriesQuery : IRequest<Response<IEnumerable<CountryViewModel>>>
    {
    }

    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, Response<IEnumerable<CountryViewModel>>>
    {
        private readonly ICountryRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetAllCountriesQueryHandler(ICountryRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CountryViewModel>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllCountriesParameter>(request);
            var _countries = await _repository.GetAllAsync();
            var _viewModel = _mapper.Map<IEnumerable<CountryViewModel>>(_countries);

            return new Response<IEnumerable<CountryViewModel>>(_viewModel);
        }
    }
}
