using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NiceTruck.Domain.Entities;

namespace NiceTruck.Domain.Interfaces.Repositories
{
    public interface ITruckRepository
    {
        Task<List<Truck>> GetAllTrucksEnablesAsync(CancellationToken cancelationToken = default);
        Task<Truck> GetDetailsTruckEnableByIdAsync(int? idTruck, CancellationToken cancelationToken = default);
        Task CreateTruckAsync(Truck truck, CancellationToken cancelationToken = default);
        Task UpdateTruckAsync(Truck truck, CancellationToken cancelationToken = default);
    }
}