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

namespace RunTeam.Application.Features.PersonalDetails.Queries.GetById
{
    public class GetPersonalDetailByIdQuery : IRequest<Response<PersonalDetail>>
    {
        public int Id { get; set; }
        public class GetPersonalDetailByIdQueryHandler : IRequestHandler<GetPersonalDetailByIdQuery, Response<PersonalDetail>>
        {
            private readonly IPersonalDetailRepositoryAsync _repository;
            public GetPersonalDetailByIdQueryHandler(IPersonalDetailRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<PersonalDetail>> Handle(GetPersonalDetailByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _repository.GetByIdAsync(query.Id);
                if (product == null) throw new ApiException($"Personal detail Not Found.");
                return new Response<PersonalDetail>(product);
            }
        }
    }
}
