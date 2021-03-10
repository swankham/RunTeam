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

namespace RunTeam.Application.Features.Contacts.Commands.Create
{
    public class CreateContactCommand : IRequest<Response<ContactAddress>>
    {
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Privince { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Response<ContactAddress>>
    {
        private readonly IContactAddressRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IContactAddressRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ContactAddress>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var _personal = _mapper.Map<ContactAddress>(request);

            //Insert personal detail to database.
            var result = await _repository.AddAsync(_personal);

            return new Response<ContactAddress>(result);
        }
    }
}
