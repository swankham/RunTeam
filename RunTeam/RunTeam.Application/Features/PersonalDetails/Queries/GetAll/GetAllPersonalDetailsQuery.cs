using AutoMapper;
using MediatR;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.PersonalDetails.Queries.GetAll
{
    public class GetAllPersonalDetailsQuery : IRequest<Response<IEnumerable<PersonalDetailViewModel>>>
    {
    }

    public class GetAllPersonalDetailsQueryHandler : IRequestHandler<GetAllPersonalDetailsQuery, Response<IEnumerable<PersonalDetailViewModel>>>
    {
        private readonly IPersonalDetailRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetAllPersonalDetailsQueryHandler(IPersonalDetailRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<PersonalDetailViewModel>>> Handle(GetAllPersonalDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllPersonalDetailsParameter>(request);
            var _personals = await _repository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<PersonalDetailViewModel>>(_personals);
            return new Response<IEnumerable<PersonalDetailViewModel>>(productViewModel);
        }
    }
}
