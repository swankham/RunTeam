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
    public class GetPersonalDetailByUserIdQuery : IRequest<Response<PersonalDetail>>
    {
        public string UserId { get; set; }
        public class GetPersonalDetailByUserIdQueryHandler : IRequestHandler<GetPersonalDetailByUserIdQuery, Response<PersonalDetail>>
        {
            private readonly IPersonalDetailRepositoryAsync _repository;
            public GetPersonalDetailByUserIdQueryHandler(IPersonalDetailRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<PersonalDetail>> Handle(GetPersonalDetailByUserIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _repository.GetByUserIdAsync(query.UserId);
                if (product == null) throw new ApiException($"Personal detail Not Found.");
                return new Response<PersonalDetail>(product);
            }
        }
    }
}
