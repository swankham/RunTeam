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

namespace RunTeam.Application.Features.Events.Queries.GetById
{
    public class GetEventByIdQuery : IRequest<Response<EventsViewModel>>
    {
        public int Id { get; set; }
        public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Response<EventsViewModel>>
        {
            private readonly IEventRepositoryAsync _repository;
            private readonly IMapper _mapper;
            public GetEventByIdQueryHandler(IEventRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
        }
            public async Task<Response<EventsViewModel>> Handle(GetEventByIdQuery query, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(query.Id);
                if (_contact == null) throw new ApiException($"Event Not Found.");

                var _viewModel = _mapper.Map<EventsViewModel>(_contact);
                return new Response<EventsViewModel>(_viewModel);
            }
        }
    }
}
