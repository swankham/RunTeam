﻿using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunTeam.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<bool> IsUniqueNameAsync(string barcode);
        Task<IReadOnlyList<Product>> GetByEventIdAsync(int eventId);
    }
}
