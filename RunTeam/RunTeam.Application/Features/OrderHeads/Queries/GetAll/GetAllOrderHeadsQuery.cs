using AutoMapper;
using MediatR;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.OrderHeads.Queries.GetAll
{
    public class GetAllOrderHeadsQuery : IRequest<Response<IEnumerable<OrderHeadViewModel>>>
    {
    }

    public class GetAllOrderHeadsQueryHandler : IRequestHandler<GetAllOrderHeadsQuery, Response<IEnumerable<OrderHeadViewModel>>>
    {
        private readonly IOrderHeadRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetAllOrderHeadsQueryHandler(IOrderHeadRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<OrderHeadViewModel>>> Handle(GetAllOrderHeadsQuery request, CancellationToken cancellationToken)
        {           
            var _personals = await _repository.GetAllAsync();
            var productViewModel = _mapper.Map<IEnumerable<OrderHeadViewModel>>(_personals);
            return new Response<IEnumerable<OrderHeadViewModel>>(productViewModel);
        }
    }
}
