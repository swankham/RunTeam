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
    public class GetOrderHeadsByUserIdQuery : IRequest<Response<IEnumerable<OrderHeadViewModel>>>
    {
        public string userId { get; set; }
    }

    public class GetOrderHeadsByUserIdQueryHandler : IRequestHandler<GetOrderHeadsByUserIdQuery, Response<IEnumerable<OrderHeadViewModel>>>
    {
        private readonly IOrderHeadRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetOrderHeadsByUserIdQueryHandler(IOrderHeadRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<OrderHeadViewModel>>> Handle(GetOrderHeadsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var _orders = await _repository.GetByUserIdAsync(request.userId);
            var _viewModel = _mapper.Map<IEnumerable<OrderHeadViewModel>>(_orders);
            return new Response<IEnumerable<OrderHeadViewModel>>(_viewModel);
        }
    }
}
