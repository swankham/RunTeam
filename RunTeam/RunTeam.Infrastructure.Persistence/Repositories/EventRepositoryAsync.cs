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
    public class EventRepositoryAsync : GenericRepositoryAsync<EventDay>, IEventRepositoryAsync
    {
        private readonly DbSet<EventDay> _event;

        public EventRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _event = dbContext.Set<EventDay>();
        }

        public Task<bool> IsUniqueEventCodeAsync(string eventCode)
        {
            return _event
                    .AllAsync(p => p.EventCode != eventCode);
        }

        public Task<bool> IsUniqueEventNameAsync(string eventName)
        {
            return _event
                    .AllAsync(p => p.EventName != eventName);
        }
    }
}
