using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BikeManagement.DataAccess.ViewModels;
using BikeManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BikeManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _service;
        private IMapper _mapper;

        public BikeController(IBikeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<BikeViewModel>>(await _service.GetAll()));
        }

        [HttpGet("{bikeId}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BikeViewModel>(await _service.GetById(id)));
        }
    }
}
