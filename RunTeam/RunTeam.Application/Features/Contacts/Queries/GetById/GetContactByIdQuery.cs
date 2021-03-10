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

namespace RunTeam.Application.Features.Contacts.Queries.GetById
{
    public class GetContactByIdQuery : IRequest<Response<ContactAddressViewModel>>
    {
        public int Id { get; set; }
        public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Response<ContactAddressViewModel>>
        {
            private readonly IContactAddressRepositoryAsync _repository;
            private readonly IMapper _mapper;
            public GetContactByIdQueryHandler(IContactAddressRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
        }
            public async Task<Response<ContactAddressViewModel>> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(query.Id);
                if (_contact == null) throw new ApiException($"Contact Address Not Found.");

                var _viewModel = _mapper.Map<ContactAddressViewModel>(_contact);
                return new Response<ContactAddressViewModel>(_viewModel);
            }
        }
    }
}
