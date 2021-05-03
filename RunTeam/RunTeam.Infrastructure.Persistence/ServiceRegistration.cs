using RunTeam.Application.Interfaces;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Infrastructure.Persistence.Contexts;
using RunTeam.Infrastructure.Persistence.Repositories;
using RunTeam.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySql(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();

            services.AddTransient<IPersonalDetailRepositoryAsync, PersonalDetailRepositoryAsync>();
            services.AddTransient<IContactAddressRepositoryAsync, ContactAddressRepositoryAsync>();
            services.AddTransient<IMedicalInfoRepositoryAsync, MedicalInfoRepositoryAsync>();
            services.AddTransient<ICountryRepositoryAsync, CountryRepositoryAsync>();
            services.AddTransient<IEventRepositoryAsync, EventRepositoryAsync>();
            services.AddTransient<IOrderHeadRepositoryAsync, OrderHeadRepositoryAsync>();
            services.AddTransient<IOrderLineRepositoryAsync, OrderLineRepositoryAsync>();
            #endregion
        }
    }
}
