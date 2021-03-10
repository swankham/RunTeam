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
    public class MedicalInfoRepositoryAsync : GenericRepositoryAsync<MedicalInfo>, IMedicalInfoRepositoryAsync
    {
        private readonly DbSet<MedicalInfo> _medicalInfo;

        public MedicalInfoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _medicalInfo = dbContext.Set<MedicalInfo>();
        }

        public async Task<MedicalInfo> GetByUserIdAsync(string userId)
        {
            return await _medicalInfo.FirstOrDefaultAsync(i => i.UserId == userId);
        }
    }
}
