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

namespace RunTeam.Application.Features.Events.Commands.Create
{
    public class CreateEventCommand : IRequest<Response<EventDay>>
    {
        public string EventCode { get; set; }
        public string EventName { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public bool EnableFlag { get; set; }
        public bool OnlineFlag { get; set; }
        public string EventDescription { get; set; }
        public int RegistrationStatus { get; set; }
        public string EventOwner { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Response<EventDay>>
    {
        private readonly IEventRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IEventRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<EventDay>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var _event = _mapper.Map<EventDay>(request);

            //Insert personal detail to database.
            var result = await _repository.AddAsync(_event);

            return new Response<EventDay>(result);
        }
    }
}
