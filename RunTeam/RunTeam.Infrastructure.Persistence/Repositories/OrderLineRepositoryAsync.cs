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
    public class OrderLineRepositoryAsync : GenericRepositoryAsync<OrderLine>, IOrderLineRepositoryAsync
    {
        private readonly DbSet<OrderLine> _line;

        public OrderLineRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _line = dbContext.Set<OrderLine>();
        }

        public async Task<IReadOnlyList<OrderLine>> GetByOrderIdAsync(int orderId)
        {
            return await _line.Where(x => x.HeaderId == orderId).ToListAsync();
        }
    }
}
