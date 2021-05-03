using MediatR;
using Microsoft.AspNetCore.Http;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Events.Commands.Update
{
    public class UpdateEventCommand : IRequest<Response<EventDay>>
    {
        public int Id { get; set; }
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
        public IFormFile ImageFile { get; set; }
        public string ImageName { get; set; }

        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Response<EventDay>>
        {
            private readonly IEventRepositoryAsync _repository;
            public UpdateEventCommandHandler(IEventRepositoryAsync repository)
            {
                _repository = repository;
            }

            public async Task<Response<EventDay>> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(command.Id);

                if (_contact == null)
                {
                    throw new ApiException($"Event Not Found.");
                }
                else
                {
                    _contact.EventCode = command.EventCode;
                    _contact.EventName = command.EventName;
                    _contact.RegistrationStartDate = command.RegistrationStartDate;
                    _contact.RegistrationEndDate = command.RegistrationEndDate;
                    _contact.EventStartDate = command.EventStartDate;
                    _contact.EventEndDate = command.EventEndDate;
                    _contact.EnableFlag = command.EnableFlag;
                    _contact.OnlineFlag = command.OnlineFlag;
                    _contact.EventDescription = command.EventDescription;
                    _contact.RegistrationStatus = command.RegistrationStatus;
                    _contact.EventOwner = command.EventOwner;
                    _contact.ImageName = command.ImageName;

                    await _repository.UpdateAsync(_contact);
                    return new Response<EventDay>(_contact);
                }
            }
        }
    }
}
