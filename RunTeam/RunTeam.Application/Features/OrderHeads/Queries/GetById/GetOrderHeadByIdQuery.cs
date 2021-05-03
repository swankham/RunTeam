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

namespace RunTeam.Application.Features.OrderHeads.Queries.GetById
{
    public class GetOrderHeadByIdQuery : IRequest<Response<OrderHeadViewModel>>
    {
        public int Id { get; set; }
        public class GetOrderHeadByIdQueryHandler : IRequestHandler<GetOrderHeadByIdQuery, Response<OrderHeadViewModel>>
        {
            private readonly IOrderHeadRepositoryAsync _repository;
            private readonly IMapper _mapper;
            public GetOrderHeadByIdQueryHandler(IOrderHeadRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<Response<OrderHeadViewModel>> Handle(GetOrderHeadByIdQuery query, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(query.Id);
                if (_contact == null) throw new ApiException($"Order Not Found.");

                var _viewModel = _mapper.Map<OrderHeadViewModel>(_contact);
                return new Response<OrderHeadViewModel>(_viewModel);
            }
        }
    }
}
