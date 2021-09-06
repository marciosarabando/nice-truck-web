using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NiceTruck.Domain.Entities;
using NiceTruck.Domain.Interfaces.Repositories;
using NiceTruck.Repository.Data;

namespace NiceTruck.Repository.Repositories
{
    public class TruckModelRepository : ITruckModelRepository
    {
        private readonly ApplicationContext _context;

        public TruckModelRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<TruckModel>> GetAllTrucksModelsEnablesAsync(CancellationToken cancelationToken = default)
        {
            return await _context.TrucksModels
                .Where(x => x.Active)
                .AsNoTracking()
                .ToListAsync(cancelationToken);
        }
    }
}