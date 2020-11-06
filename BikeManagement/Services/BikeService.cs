using AutoMapper;
using BikeManagement.DataAccess.Models;
using BikeManagement.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeManagement.Services
{
    public class BikeService : IBikeService
    {
        private IGenericRepository<Bike> _repository = null;
        private IMapper _mapper;
        public BikeService(IGenericRepository<Bike> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Bike>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Bike> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
