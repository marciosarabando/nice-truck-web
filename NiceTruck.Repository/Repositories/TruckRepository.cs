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

        public Task CreateTruckAsync(Truck truck, CancellationToken cancelationToken = default)
        {
            return Task.Run(() =>
            {
                truck.DateTimeCreated = DateTime.Now;
                truck.Active = true;

                _context.AddAsync(truck);
                _context.SaveChangesAsync(cancelationToken);
            });
        }

        public Task UpdateTruckAsync(Truck truck, CancellationToken cancelationToken = default)
        {
            return Task.Run(() =>
            {
                truck.DateTimeUpdated = DateTime.Now;

                _context.Update(truck);
                _context.SaveChangesAsync(cancelationToken);
            });
        }

        public async Task DeleteTruckAsync(int? idTruck, CancellationToken cancelationToken = default)
        {
            var truck = await _context.Trucks
                .Where(x => x.Active && x.Id == idTruck)
                .FirstOrDefaultAsync(cancelationToken);

            if (truck == null)
                return;

            truck.Active = false;
            truck.DateTimeUpdated = DateTime.Now;

            _context.Update(truck);
            await _context.SaveChangesAsync(cancelationToken);
        }
    }
}