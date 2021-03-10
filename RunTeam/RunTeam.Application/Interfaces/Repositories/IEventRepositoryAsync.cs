using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Application.Interfaces.Repositories
{
    public interface IEventRepositoryAsync : IGenericRepositoryAsync<EventDay>
    {
        Task<bool> IsUniqueEventCodeAsync(string eventCode);
        Task<bool> IsUniqueEventNameAsync(string eventName);
    }
}
