using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Application.Interfaces.Repositories
{
    public interface IPersonalDetailRepositoryAsync : IGenericRepositoryAsync<PersonalDetail>
    {
        Task<PersonalDetail> GetByUserIdAsync(string userId);
    }
}
