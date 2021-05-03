using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Application.Interfaces.Repositories
{
    public interface IOrderHeadRepositoryAsync : IGenericRepositoryAsync<OrderHead>
    {
        Task<IReadOnlyList<OrderHead>> GetByUserIdAsync(string userId);
        Task<IReadOnlyList<OrderHead>> GetByEventIdAsync(int eventId);
        Task<IReadOnlyList<OrderHead>> GetByStatusAsync(int status);
        Task<int> GetLastIdAsync();
    }
}
