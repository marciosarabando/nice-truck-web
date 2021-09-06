using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NiceTruck.Application.Interfaces;
using NiceTruck.Application.ViewModels;
using NiceTruck.Domain.Entities;
using NiceTruck.Domain.Interfaces.Repositories;

namespace NiceTruck.Application.BLL
{
    public class TruckBll : ITruckBll
    {
        private readonly ITruckRepository _truckRepository;
        private readonly ITruckModelRepository _truckModelRepository;
        private readonly IMapper _mapper;

        public TruckBll(ITruckRepository truckRepository
            , IMapper mapper
            , ITruckModelRepository truckModelRepository)
        {
            _truckRepository = truckRepository;
            _truckModelRepository = truckModelRepository;
            _mapper = mapper;
        }

        public async Task<List<TruckViewModel>> GetAllTrucksEnablesAsync(CancellationToken cancelationToken = default)
        {
            var trucks = await _truckRepository.GetAllTrucksEnablesAsync(cancelationToken);

            return _mapper.Map<List<TruckViewModel>>(trucks);
        }

        public async Task<TruckViewModelDetails> GetDetailsTruckEnableByIdAsync(int? idTruck, CancellationToken cancelationToken = default)
        {
            var truck = await _truckRepository.GetDetailsTruckEnableByIdAsync(idTruck, cancelationToken);

            return _mapper.Map<TruckViewModelDetails>(truck);
        }

        public async Task<TruckViewModel> PopulateTruckModels(TruckViewModel truckModel, CancellationToken cancelationToken = default)
        {
            truckModel.TruckModels = _mapper.Map<IEnumerable<TruckModelViewModel>>(await _truckModelRepository.GetAllTrucksModelsEnablesAsync(cancelationToken));

            return truckModel;
        }

        public async Task CreateTruckAsync(TruckViewModel truckModel, CancellationToken cancelationToken = default)
        {
            var truck = _mapper.Map<Truck>(truckModel);

            await _truckRepository.CreateTruckAsync(truck, cancelationToken);
        }

        public async Task<TruckViewModel> GetTruckEnableByIdAsync(int? idTruck, CancellationToken cancelationToken = default)
        {
            var truck = await _truckRepository.GetDetailsTruckEnableByIdAsync(idTruck, cancelationToken);

            return _mapper.Map<TruckViewModel>(truck);
        }

        public async Task UpdateTruckAsync(int? idTruck, TruckViewModel truckModel, CancellationToken cancelationToken = default)
        {
            var truck = await _truckRepository.GetDetailsTruckEnableByIdAsync(idTruck, cancelationToken);

            var truckUpdated = _mapper.Map(truckModel, truck);

            await _truckRepository.UpdateTruckAsync(truckUpdated, cancelationToken);
        }

        public async Task DeleteTruckAsync(int? idTruck, CancellationToken cancelationToken = default)
        {
            await _truckRepository.DeleteTruckAsync(idTruck, cancelationToken);
        }
    }
}