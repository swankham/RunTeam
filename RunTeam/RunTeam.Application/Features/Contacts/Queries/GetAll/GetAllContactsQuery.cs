using AutoMapper;
using MediatR;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Contacts.Queries.GetAll
{
    public class GetAllContactsQuery : IRequest<Response<IEnumerable<ContactAddressViewModel>>>
    {
    }

    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, Response<IEnumerable<ContactAddressViewModel>>>
    {
        private readonly IContactAddressRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetAllContactsQueryHandler(IContactAddressRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ContactAddressViewModel>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllContactsParameter>(request);
            var _personals = await _repository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<ContactAddressViewModel>>(_personals);
            return new Response<IEnumerable<ContactAddressViewModel>>(productViewModel);
        }
    }
}
