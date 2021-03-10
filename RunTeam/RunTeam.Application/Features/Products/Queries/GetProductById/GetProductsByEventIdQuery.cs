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

namespace RunTeam.Application.Features.Products.Queries.GetProductById
{
    public class GetProductsByEventIdQuery : IRequest<Response<IEnumerable<GetAllProductsViewModel>>>
    {
        public int EventId { get; set; }
        public class GetContactByUserIdQueryHandler : IRequestHandler<GetProductsByEventIdQuery, Response<IEnumerable<GetAllProductsViewModel>>>
        {
            private readonly IProductRepositoryAsync _repository;
            private readonly IMapper _mapper;

            public GetContactByUserIdQueryHandler(IProductRepositoryAsync repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<Response<IEnumerable<GetAllProductsViewModel>>> Handle(GetProductsByEventIdQuery query, CancellationToken cancellationToken)
            {
                var _products = await _repository.GetByEventIdAsync(query.EventId);
                if (_products == null) throw new ApiException($"Products Not Found.");

                var productViewModel = _mapper.Map<IEnumerable<GetAllProductsViewModel>>(_products);
                return new Response<IEnumerable<GetAllProductsViewModel>>(productViewModel);
            }
        }
    }
}
