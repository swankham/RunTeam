using Microsoft.EntityFrameworkCore;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Domain.Entities;
using RunTeam.Infrastructure.Persistence.Contexts;
using RunTeam.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Infrastructure.Persistence.Repositories
{
    public class OrderHeadRepositoryAsync : GenericRepositoryAsync<OrderHead>, IOrderHeadRepositoryAsync
    {
        private readonly DbSet<OrderHead> _head;

        public OrderHeadRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _head = dbContext.Set<OrderHead>();
        }

        public async Task<IReadOnlyList<OrderHead>> GetByEventIdAsync(int eventId)
        {
            return await _head.Where(x => x.EventId == eventId).ToListAsync();
        }

        public async Task<IReadOnlyList<OrderHead>> GetByStatusAsync(int status)
        {
            return await _head.Where(x => x.Status == status).ToListAsync();
        }

        public async Task<IReadOnlyList<OrderHead>> GetByUserIdAsync(string userId)
        {
            return await _head.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<int> GetLastIdAsync()
        {
                int _last = await _head.CountAsync();
                return _last + 1;
        }
    }
}
