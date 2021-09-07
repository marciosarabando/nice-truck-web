using System;
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
    public class TruckRepository : ITruckRepository
    {
        private readonly ApplicationContext _context;

        public TruckRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Truck>> GetAllTrucksEnablesAsync(CancellationToken cancelationToken = default)
        {
            return await _context.Trucks
                .Include(x => x.TruckModel)
                .Where(x => x.Active)
                .AsNoTracking()
                .ToListAsync(cancelationToken);
        }

        public async Task<Truck> GetDetailsTruckEnableByIdAsync(int? idTruck, CancellationToken cancelationToken = default)
        {
            return await _context.Trucks
                .Include(x => x.TruckModel)
                .Where(x => x.Active && x.Id == idTruck)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancelationToken);
        }

        public async Task CreateTruckAsync(Truck truck, CancellationToken cancelationToken = default)
        {
            _context.Add(truck);
            await _context.SaveChangesAsync(cancelationToken);
        }

        public async Task UpdateTruckAsync(Truck truck, CancellationToken cancelationToken = default)
        {
            _context.Update(truck);
            await _context.SaveChangesAsync(cancelationToken);
        }
    }
}