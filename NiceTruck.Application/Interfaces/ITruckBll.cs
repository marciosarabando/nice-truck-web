using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NiceTruck.Application.ViewModels;

namespace NiceTruck.Application.Interfaces
{
    public interface ITruckBll
    {
        Task<List<TruckViewModel>> GetAllTrucksEnablesAsync(CancellationToken cancelationToken = default);
        Task<TruckViewModelDetails> GetDetailsTruckEnableByIdAsync(int? idTruck, CancellationToken cancelationToken = default);
        Task<TruckViewModel> GetTruckEnableByIdAsync(int? idTruck, CancellationToken cancelationToken = default);
        Task<TruckViewModel> PopulateTruckModels(TruckViewModel truckModel, CancellationToken cancelationToken = default);
        Task CreateTruckAsync(TruckViewModel truckModel, CancellationToken cancelationToken = default);
        Task UpdateTruckAsync(int? idTruck, TruckViewModel truckModel, CancellationToken cancelationToken = default);
        Task DeleteTruckAsync(int? idTruck, CancellationToken cancelationToken = default);
    }
}