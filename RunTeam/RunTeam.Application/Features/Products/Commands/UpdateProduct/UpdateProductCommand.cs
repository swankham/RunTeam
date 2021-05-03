using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
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
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<int>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public UpdateProductCommandHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<int>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id);

                if (product == null)
                {
                    throw new ApiException($"Product Not Found.");
                }
                else
                {
                    product.Name = command.Name;
                    product.Description = command.Description;
                    product.EnableFlag = command.EnableFlag;
                    product.StartActiveDate = command.StartActiveDate.AddMinutes(1);
                    product.EndActiveDate = command.EndActiveDate.AddMinutes(1);
                    product.CutOffTimeMin = command.CutOffTimeMin;
                    product.Segment1 = command.Segment1;
                    product.Segment2 = command.Segment2;
                    product.Segment3 = command.Segment3;
                    product.Segment4 = command.Segment4;
                    product.Segment5 = command.Segment5;
                    product.ShippableItemFlag = command.ShippableItemFlag;
                    product.CustomerOrderFlag = command.CustomerOrderFlag;
                    product.ServiceItemFlag = command.ServiceItemFlag;
                    product.ItemCatalogId = command.ItemCatalogId;
                    product.PricePerUnit = command.PricePerUnit;
                    product.PrimaryUomCode = command.PrimaryUomCode;
                    product.RegistrationStatus = command.RegistrationStatus;
                    product.RegisterLimit = command.RegisterLimit;
                    product.EventId = command.EventId;

                    await _productRepository.UpdateAsync(product);
                    return new Response<int>(product.Id);
                }
            }
        }
    }
}
