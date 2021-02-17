using RunTeam.Application.Features.Products.Commands.CreateProduct;
using RunTeam.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
