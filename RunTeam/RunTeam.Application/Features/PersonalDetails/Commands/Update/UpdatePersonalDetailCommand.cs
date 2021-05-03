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

namespace RunTeam.Application.Features.PersonalDetails.Commands.Update
{
    public class UpdatePersonalDetailCommand : IRequest<Response<PersonalDetail>>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ThaiCitizenId { get; set; }
        public string PassportId { get; set; }
        public int NotionalityId { get; set; }
        public string Prefix { get; set; }
        public string FirstnameTh { get; set; }
        public string MiddlenameTh { get; set; }
        public string LastnameTh { get; set; }
        public string FirstnameEn { get; set; }
        public string MiddlenameEn { get; set; }
        public string LastnameEn { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string HealthIssues { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageName { get; set; }

        public class UpdatePersonalDetailCommandHandler : IRequestHandler<UpdatePersonalDetailCommand, Response<PersonalDetail>>
        {
            private readonly IPersonalDetailRepositoryAsync _repository;
            public UpdatePersonalDetailCommandHandler(IPersonalDetailRepositoryAsync repository)
            {
                _repository = repository;
            }

            public async Task<Response<PersonalDetail>> Handle(UpdatePersonalDetailCommand command, CancellationToken cancellationToken)
            {
                var _personal = await _repository.GetByIdAsync(command.Id);

                if (_personal == null)
                {
                    throw new ApiException($"Personal detail Not Found.");
                }
                else
                {
                    _personal.UserId = command.UserId;
                    _personal.ThaiCitizenId = command.ThaiCitizenId;
                    _personal.PassportId = command.PassportId;
                    _personal.NotionalityId = command.NotionalityId;
                    _personal.Prefix = command.Prefix;
                    _personal.FirstnameTh = command.FirstnameTh;
                    _personal.MiddlenameTh = command.MiddlenameTh;
                    _personal.LastnameTh = command.LastnameTh;
                    _personal.FirstnameEn = command.FirstnameEn;
                    _personal.MiddlenameEn = command.MiddlenameEn;
                    _personal.LastnameEn = command.LastnameEn;
                    _personal.BirthDay = command.BirthDay;
                    _personal.Gender = command.Gender;
                    _personal.Address = command.Address;
                    _personal.Province = command.Province;
                    _personal.CountryId = command.CountryId;
                    _personal.Phone = command.Phone;
                    _personal.PostalCode = command.PostalCode;
                    _personal.EmailAddress = command.EmailAddress;
                    _personal.HealthIssues = command.HealthIssues;
                    _personal.BloodGroup = command.BloodGroup;
                    _personal.EmergencyContact = command.EmergencyContact;
                    _personal.EmergencyPhone = command.EmergencyPhone;
                    _personal.ImageName = command.ImageName;

                    await _repository.UpdateAsync(_personal);
                    return new Response<PersonalDetail>(_personal);
                }
            }
        }
    }
}
