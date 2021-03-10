using RunTeam.Application.Features.Products.Commands.CreateProduct;
using RunTeam.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using RunTeam.Application.Features.PersonalDetails.Queries;
using RunTeam.Application.Features.PersonalDetails.Queries.GetAll;
using RunTeam.Application.Features.PersonalDetails.Commands.Create;
using RunTeam.Application.Features.Contacts.Queries;
using RunTeam.Application.Features.Contacts.Commands.Create;
using RunTeam.Application.Features.Contacts.Queries.GetAll;
using RunTeam.Application.Features.MedicalInfos.Queries;
using RunTeam.Application.Features.MedicalInfos.Commands.Create;
using RunTeam.Application.Features.MedicalInfos.Queries.GetAll;
using RunTeam.Application.Features.Countries.Queries;
using RunTeam.Application.Features.Countries.Commands.Create;
using RunTeam.Application.Features.Countries.Queries.GetAll;
using RunTeam.Application.Features.Events.Commands.Create;
using RunTeam.Application.Features.Events.Queries.GetAll;
using RunTeam.Application.Features.Events.Queries;
using RunTeam.Application.Features.Products.Queries;

namespace RunTeam.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<PersonalDetail, PersonalDetailViewModel>().ReverseMap();
            CreateMap<CreatePersornalDetailCommand, PersonalDetail>();
            CreateMap<GetAllPersonalDetailsQuery, GetAllPersonalDetailsParameter>();

            CreateMap<ContactAddress, ContactAddressViewModel>().ReverseMap();
            CreateMap<CreateContactCommand, ContactAddress>();
            CreateMap<GetAllContactsQuery, GetAllContactsParameter>();

            CreateMap<MedicalInfo, MedicalInfoViewModel>().ReverseMap();
            CreateMap<CreateMedicalInfoCommand, MedicalInfo>();
            CreateMap<GetAllMedicalInfosQuery, GetAllMedicalInfosParameter>();

            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<CreateCountryCommand, Country>();
            CreateMap<GetAllCountriesQuery, GetAllCountriesParameter>();

            CreateMap<EventDay, EventsViewModel>().ReverseMap();
            CreateMap<CreateEventCommand, EventDay>();
            CreateMap<GetAllEventsQuery, GetAllEventsParameter>();
        }
    }
}
