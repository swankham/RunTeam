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

namespace RunTeam.Application.Features.MedicalInfos.Queries.GetById
{
    public class GetMedicalInfoByUserIdQuery : IRequest<Response<MedicalInfoViewModel>>
    {
        public string UserId { get; set; }
        public class GetMedicalInfoByUserIdQueryHandler : IRequestHandler<GetMedicalInfoByUserIdQuery, Response<MedicalInfoViewModel>>
        {
            private readonly IMedicalInfoRepositoryAsync _repository;
            private readonly IMapper _mapper;
            
            public GetMedicalInfoByUserIdQueryHandler(IMedicalInfoRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<Response<MedicalInfoViewModel>> Handle(GetMedicalInfoByUserIdQuery query, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByUserIdAsync(query.UserId);
                if (_contact == null) throw new ApiException($"Medical information Not Found.");

                var _viewModel = _mapper.Map<MedicalInfoViewModel>(_contact);
                return new Response<MedicalInfoViewModel>(_viewModel);
            }
        }
    }
}
