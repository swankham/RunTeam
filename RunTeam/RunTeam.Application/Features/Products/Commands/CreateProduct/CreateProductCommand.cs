using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using AutoMapper;
using RunTeam.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace RunTeam.Application.Features.Products.Commands.CreateProduct
{
    public partial class CreateProductCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool EnableFlag { get; set; }
        public DateTime StartActiveDate { get; set; }
        public DateTime EndActiveDate { get; set; }
        public int CutOffTimeMin { get; set; }
        public string Segment1 { get; set; }
        public string Segment2 { get; set; }
        public string Segment3 { get; set; }
        public string Segment4 { get; set; }
        public string Segment5 { get; set; }
        public bool ShippableItemFlag { get; set; }
        public bool CustomerOrderFlag { get; set; }
        public bool ServiceItemFlag { get; set; }
        public int ItemCatalogId { get; set; }
        public decimal PricePerUnit { get; set; }
        public string PrimaryUomCode { get; set; }
        public int RegistrationStatus { get; set; }
        public int RegisterLimit { get; set; }
        public int EventId { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product);
            return new Response<int>(product.Id);
        }
    }
}
