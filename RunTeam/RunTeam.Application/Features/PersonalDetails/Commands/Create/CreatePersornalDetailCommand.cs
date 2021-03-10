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

namespace RunTeam.Application.Features.PersonalDetails.Commands.Create
{
    public class CreatePersornalDetailCommand : IRequest<Response<PersonalDetail>>
    {
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
    }

    public class CreatePersornalDetailCommandHandler : IRequestHandler<CreatePersornalDetailCommand, Response<PersonalDetail>>
    {
        private readonly IPersonalDetailRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public CreatePersornalDetailCommandHandler(IPersonalDetailRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<PersonalDetail>> Handle(CreatePersornalDetailCommand request, CancellationToken cancellationToken)
        {
            var _personal = _mapper.Map<PersonalDetail>(request);

            //Insert personal detail to database.
            var result = await _repository.AddAsync(_personal);

            return new Response<PersonalDetail>(result);
        }
    }
}
