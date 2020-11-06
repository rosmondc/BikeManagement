using AutoMapper;
using BikeManagement.DataAccess.ViewModels;
using BikeManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BikeRentHistoryController : ControllerBase
    {
        private readonly IBikeRentHistoryService _service;
        private IMapper _mapper;

        public BikeRentHistoryController(IBikeRentHistoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<BikeRentHistoryViewModel>>(await _service.GetAll()));
        }

        [HttpGet("{bikeId}")]
        public async Task<ActionResult> GetById(int bikeId)
        {
            return Ok(_mapper.Map<BikeRentHistoryViewModel>(await _service.GetById(bikeId)));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> SaveBikeRentHistory([FromBody] BikeRentHistoryViewModel bikeRentHistory)
        {           
            return Ok(_mapper.Map<BikeRentHistoryViewModel>(await _service.Save(bikeRentHistory)));
        }
       
    }
}
