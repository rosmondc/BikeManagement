using BikeManagement.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeManagement.Services
{
    public interface IBikeService
    {
        Task<IEnumerable<Bike>> GetAll();
        Task<Bike> GetById(int id);
    }
}