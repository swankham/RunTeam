using Microsoft.EntityFrameworkCore;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Domain.Entities;
using RunTeam.Infrastructure.Persistence.Contexts;
using RunTeam.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Infrastructure.Persistence.Repositories
{
    public class CountryRepositoryAsync : GenericRepositoryAsync<Country>, ICountryRepositoryAsync
    {
        private readonly DbSet<Country> _country;

        public CountryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _country = dbContext.Set<Country>();
        }

        public Task<bool> IsUniqueCountryCodeAsync(string countryCode)
        {
            return _country
                    .AllAsync(p => p.CountryCode != countryCode);
        }

        public Task<bool> IsUniqueCountryNameAsync(string countryName)
        {
            return _country
                    .AllAsync(p => p.CountryName != countryName);
        }

    }
}
