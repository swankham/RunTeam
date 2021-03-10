using AutoMapper;
using MediatR;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Events.Queries.GetAll
{
    public class GetAllEventsQuery : IRequest<Response<IEnumerable<EventsViewModel>>>
    {
    }

    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, Response<IEnumerable<EventsViewModel>>>
    {
        private readonly IEventRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetAllEventsQueryHandler(IEventRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<EventsViewModel>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllEventsParameter>(request);
            var _personals = await _repository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<EventsViewModel>>(_personals);
            return new Response<IEnumerable<EventsViewModel>>(productViewModel);
        }
    }
}
