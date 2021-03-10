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
    public class PersonalDetailRepositoryAsync : GenericRepositoryAsync<PersonalDetail>, IPersonalDetailRepositoryAsync
    {
        private readonly DbSet<PersonalDetail> _personalDetail;

        public PersonalDetailRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _personalDetail = dbContext.Set<PersonalDetail>();
        }

        public async Task<PersonalDetail> GetByUserIdAsync(string userId)
        {
            return await _personalDetail.FirstOrDefaultAsync(i => i.UserId == userId);
        }
    }
}
