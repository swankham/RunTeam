using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Application.Interfaces.Repositories
{
    public interface IContactAddressRepositoryAsync : IGenericRepositoryAsync<ContactAddress>
    {
        Task<ContactAddress> GetByUserIdAsync(string userId);
    }
}
