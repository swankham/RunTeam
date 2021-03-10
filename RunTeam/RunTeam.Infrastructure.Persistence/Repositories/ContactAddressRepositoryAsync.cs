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
    public class ContactAddressRepositoryAsync : GenericRepositoryAsync<ContactAddress>, IContactAddressRepositoryAsync
    {
        private readonly DbSet<ContactAddress> _contactAddress;

        public ContactAddressRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _contactAddress = dbContext.Set<ContactAddress>();
        }

        public async Task<ContactAddress> GetByUserIdAsync(string userId)
        {
            return await _contactAddress.FirstOrDefaultAsync(i => i.UserId == userId);
        }
    }
}
