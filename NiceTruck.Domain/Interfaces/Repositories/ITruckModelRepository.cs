using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NiceTruck.Domain.Entities;

namespace NiceTruck.Domain.Interfaces.Repositories
{
    public interface ITruckModelRepository
    {
        Task<List<TruckModel>> GetAllTrucksModelsEnablesAsync(CancellationToken cancelationToken = default);
    }
}