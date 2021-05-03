using AutoMapper;
using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.OrderLines.Queries.GetById
{
    public class GetOrderLineByIdQuery : IRequest<Response<OrderLineViewModel>>
    {
        public int Id { get; set; }
        public class GetOrderHeadByIdQueryHandler : IRequestHandler<GetOrderLineByIdQuery, Response<OrderLineViewModel>>
        {
            private readonly IOrderLineRepositoryAsync _repository;
            private readonly IMapper _mapper;
            public GetOrderHeadByIdQueryHandler(IOrderLineRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<Response<OrderLineViewModel>> Handle(GetOrderLineByIdQuery query, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(query.Id);
                if (_contact == null) throw new ApiException($"Order line not found.");

                var _viewModel = _mapper.Map<OrderLineViewModel>(_contact);
                return new Response<OrderLineViewModel>(_viewModel);
            }
        }
    }
}
