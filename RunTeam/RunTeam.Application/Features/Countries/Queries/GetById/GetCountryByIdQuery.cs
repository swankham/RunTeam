using AutoMapper;
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

namespace RunTeam.Application.Features.Countries.Queries.GetById
{
    public class GetCountryByIdQuery : IRequest<Response<CountryViewModel>>
    {
        public int Id { get; set; }
        public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Response<CountryViewModel>>
        {
            private readonly ICountryRepositoryAsync _repository;
            private readonly IMapper _mapper;
            public GetCountryByIdQueryHandler(ICountryRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
        }
            public async Task<Response<CountryViewModel>> Handle(GetCountryByIdQuery query, CancellationToken cancellationToken)
            {
                var _country = await _repository.GetByIdAsync(query.Id);
                if (_country == null) throw new ApiException($"Country Not Found.");

                var _viewModel = _mapper.Map<CountryViewModel>(_country);
                return new Response<CountryViewModel>(_viewModel);
            }
        }
    }
}
