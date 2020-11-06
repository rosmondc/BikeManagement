using BikeManagement.DataAccess.Models;
using BikeManagement.DataAccess.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeManagement.Services
{
    public interface IBikeRentHistoryService
    {
        Task<IEnumerable<BikeRentHistory>> GetAll();
        Task<BikeRentHistory> GetById(int id);
        Task<BikeRentHistory> Save(BikeRentHistoryViewModel bikeRentHistory);
    }
}