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

namespace RunTeam.Application.Features.MedicalInfos.Commands.Create
{
    public class CreateMedicalInfoCommand : IRequest<Response<MedicalInfo>>
    {
        public string UserId { get; set; }
        public string HealthIssues { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyContact { get; set; }
        public string Phone { get; set; }
    }

    public class CreateMedicalInfoCommandHandler : IRequestHandler<CreateMedicalInfoCommand, Response<MedicalInfo>>
    {
        private readonly IMedicalInfoRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public CreateMedicalInfoCommandHandler(IMedicalInfoRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<MedicalInfo>> Handle(CreateMedicalInfoCommand request, CancellationToken cancellationToken)
        {
            var _personal = _mapper.Map<MedicalInfo>(request);

            //Insert personal detail to database.
            var result = await _repository.AddAsync(_personal);

            return new Response<MedicalInfo>(result);
        }
    }
}
