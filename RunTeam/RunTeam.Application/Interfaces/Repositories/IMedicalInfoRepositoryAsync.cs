using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Application.Interfaces.Repositories
{
    public interface IMedicalInfoRepositoryAsync : IGenericRepositoryAsync<MedicalInfo>
    {
        Task<MedicalInfo> GetByUserIdAsync(string userId);
    }
}
