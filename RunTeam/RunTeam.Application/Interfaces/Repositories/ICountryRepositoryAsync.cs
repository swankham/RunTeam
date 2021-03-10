using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Application.Interfaces.Repositories
{
    public interface ICountryRepositoryAsync : IGenericRepositoryAsync<Country>
    {
        Task<bool> IsUniqueCountryCodeAsync(string countryCode);
        Task<bool> IsUniqueCountryNameAsync(string countryName);
    }
}
