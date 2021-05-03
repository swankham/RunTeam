using AutoMapper;
using MediatR;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.OrderLines.Queries.GetAll
{
    public class GetAllLinesByOrderIdQuery : IRequest<Response<IEnumerable<OrderLineViewModel>>>
    {
        public int OrderId { get; set; }

        public class GetAllLinesByOrderIdQueryHandler : IRequestHandler<GetAllLinesByOrderIdQuery, Response<IEnumerable<OrderLineViewModel>>>
        {
            private readonly IOrderLineRepositoryAsync _repository;
            private readonly IMapper _mapper;
            public GetAllLinesByOrderIdQueryHandler(IOrderLineRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<OrderLineViewModel>>> Handle(GetAllLinesByOrderIdQuery request, CancellationToken cancellationToken)
            {
                var _lines = await _repository.GetByOrderIdAsync(request.OrderId);
                var _viewModel = _mapper.Map<IEnumerable<OrderLineViewModel>>(_lines);
                return new Response<IEnumerable<OrderLineViewModel>>(_viewModel);
            }
        }
    }
}
