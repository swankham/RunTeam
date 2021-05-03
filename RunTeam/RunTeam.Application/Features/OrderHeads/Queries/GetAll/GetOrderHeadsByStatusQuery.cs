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
    public class GetOrderHeadsByStatusQuery : IRequest<Response<IEnumerable<OrderHeadViewModel>>>
    {
        public int status { get; set; }
    }

    public class GetOrderHeadsByStatusQueryHandler : IRequestHandler<GetOrderHeadsByStatusQuery, Response<IEnumerable<OrderHeadViewModel>>>
    {
        private readonly IOrderHeadRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetOrderHeadsByStatusQueryHandler(IOrderHeadRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<OrderHeadViewModel>>> Handle(GetOrderHeadsByStatusQuery request, CancellationToken cancellationToken)
        {
            var _orders = await _repository.GetByStatusAsync(request.status);
            var _viewModel = _mapper.Map<IEnumerable<OrderHeadViewModel>>(_orders);
            return new Response<IEnumerable<OrderHeadViewModel>>(_viewModel);
        }
    }
}
