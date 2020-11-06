using AutoMapper;
using BikeManagement.DataAccess.Models;
using BikeManagement.DataAccess.ViewModels;

namespace PlaneBooking.DataAccess
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bike, BikeViewModel>();
            CreateMap<BikeRentHistory, BikeRentHistoryViewModel>();
        }
    }
}
