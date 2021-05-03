using AutoMapper;
using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Features.OrderHeads.Queries;
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
    public class GetMedicalInfoByIdQuery : IRequest<Response<OrderHeadViewModel>>
    {
        public int Id { get; set; }
        public class GetMedicalInfoByIdQueryHandler : IRequestHandler<GetMedicalInfoByIdQuery, Response<OrderHeadViewModel>>
        {
            private readonly IMedicalInfoRepositoryAsync _repository;
            private readonly IMapper _mapper;
            public GetMedicalInfoByIdQueryHandler(IMedicalInfoRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
        }
            public async Task<Response<OrderHeadViewModel>> Handle(GetMedicalInfoByIdQuery query, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(query.Id);
                if (_contact == null) throw new ApiException($"Medical information Not Found.");

                var _viewModel = _mapper.Map<OrderHeadViewModel>(_contact);
                return new Response<OrderHeadViewModel>(_viewModel);
            }
        }
    }
}
