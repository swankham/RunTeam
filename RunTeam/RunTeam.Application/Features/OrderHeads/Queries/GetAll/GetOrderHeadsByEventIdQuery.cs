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
    public class GetOrderHeadsByEventIdQuery : IRequest<Response<IEnumerable<OrderHeadViewModel>>>
    {
        public int eventId { get; set; }
    }

    public class GetOrderHeadsByEventIdQueryHandler : IRequestHandler<GetOrderHeadsByEventIdQuery, Response<IEnumerable<OrderHeadViewModel>>>
    {
        private readonly IOrderHeadRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetOrderHeadsByEventIdQueryHandler(IOrderHeadRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<OrderHeadViewModel>>> Handle(GetOrderHeadsByEventIdQuery request, CancellationToken cancellationToken)
        {
            var _orders = await _repository.GetByEventIdAsync(request.eventId);
            var _viewModel = _mapper.Map<IEnumerable<OrderHeadViewModel>>(_orders);
            return new Response<IEnumerable<OrderHeadViewModel>>(_viewModel);
        }
    }
}
