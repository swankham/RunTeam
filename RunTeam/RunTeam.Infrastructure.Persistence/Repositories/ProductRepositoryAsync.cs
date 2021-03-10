using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Domain.Entities;
using RunTeam.Infrastructure.Persistence.Contexts;
using RunTeam.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RunTeam.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
        }

        public async Task<IReadOnlyList<Product>> GetByEventIdAsync(int eventId)
        {
            return await _products.Where(x => x.EventId == eventId).ToListAsync();
        }

        public Task<bool> IsUniqueNameAsync(string name)
        {
            return _products
                .AllAsync(p => p.Name != name);
        }
    }
}
