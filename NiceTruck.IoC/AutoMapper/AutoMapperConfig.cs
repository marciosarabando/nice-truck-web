using AutoMapper;
using NiceTruck.Application.ViewModels;
using NiceTruck.Domain.Entities;

namespace NiceTruck.IoC.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Truck, TruckViewModel>().ReverseMap();
            CreateMap<Truck, TruckViewModelDetails>().ReverseMap();
            CreateMap<TruckModel, TruckModelViewModel>().ReverseMap();
        }
    }
}