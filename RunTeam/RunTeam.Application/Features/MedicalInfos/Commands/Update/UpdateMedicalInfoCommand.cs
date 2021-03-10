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

namespace RunTeam.Application.Features.MedicalInfos.Commands.Update
{
    public class UpdateMedicalInfoCommand : IRequest<Response<MedicalInfo>>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string HealthIssues { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyContact { get; set; }
        public string Phone { get; set; }

        public class UpdateMedicalInfoCommandHandler : IRequestHandler<UpdateMedicalInfoCommand, Response<MedicalInfo>>
        {
            private readonly IMedicalInfoRepositoryAsync _repository;
            public UpdateMedicalInfoCommandHandler(IMedicalInfoRepositoryAsync repository)
            {
                _repository = repository;
            }

            public async Task<Response<MedicalInfo>> Handle(UpdateMedicalInfoCommand command, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(command.Id);

                if (_contact == null)
                {
                    throw new ApiException($"Medical Infomation Not Found.");
                }
                else
                {
                    _contact.UserId = command.UserId;
                    _contact.HealthIssues = command.HealthIssues;
                    _contact.BloodGroup = command.BloodGroup;
                    _contact.EmergencyContact = command.EmergencyContact;
                    _contact.Phone = command.Phone;

                    await _repository.UpdateAsync(_contact);
                    return new Response<MedicalInfo>(_contact);
                }
            }
        }
    }
}
