using AutoMapper;
using MediatR;
using RunTeam.Application.Features.OrderHeads.Queries;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.MedicalInfos.Queries.GetAll
{
    public class GetAllMedicalInfosQuery : IRequest<Response<IEnumerable<OrderHeadViewModel>>>
    {
    }

    public class GetAllMedicalInfosQueryHandler : IRequestHandler<GetAllMedicalInfosQuery, Response<IEnumerable<OrderHeadViewModel>>>
    {
        private readonly IMedicalInfoRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetAllMedicalInfosQueryHandler(IMedicalInfoRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<OrderHeadViewModel>>> Handle(GetAllMedicalInfosQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllMedicalInfosParameter>(request);
            var _personals = await _repository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<OrderHeadViewModel>>(_personals);
            return new Response<IEnumerable<OrderHeadViewModel>>(productViewModel);
        }
    }
}
