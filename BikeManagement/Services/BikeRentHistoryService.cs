using BikeManagement.DataAccess.Models;
using BikeManagement.DataAccess.ViewModels;
using BikeManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeManagement.Services
{
    public class BikeRentHistoryService : IBikeRentHistoryService
    {
        private IGenericRepository<BikeRentHistory> _repository = null;
        private readonly IBikeService _bikeService;

        public BikeRentHistoryService(IGenericRepository<BikeRentHistory> repository, IBikeService bikeService)
        {
            _repository = repository;
            _bikeService = bikeService;
        }

        public async Task<IEnumerable<BikeRentHistory>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<BikeRentHistory> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<BikeRentHistory> Save(BikeRentHistoryViewModel bikeRentHistory)
        {
            var checkInTime = Convert.ToDateTime(bikeRentHistory.CheckInTime);
            var checkOutTime = Convert.ToDateTime(bikeRentHistory.CheckOutTime);
            var bike = await _bikeService.GetById(Convert.ToInt32(bikeRentHistory.BikeId));

            if (checkInTime > checkOutTime)
                return null; 

            var bikeHistory = new BikeRentHistory
            {
                Bike = bike,
                CustomerName = bikeRentHistory.CustomerName,
                CheckInTime = checkInTime,
                CheckOutTime = checkOutTime,
                TimeSpent = checkInTime.Subtract(checkOutTime).TotalHours,
                DateModified = DateTime.Now
            };

            return await _repository.AddAsync(bikeHistory);
        }
    }
}
