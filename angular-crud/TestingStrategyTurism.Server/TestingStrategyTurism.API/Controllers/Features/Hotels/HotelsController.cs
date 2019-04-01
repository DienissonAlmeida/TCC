using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Application;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Data.Features;
using TestEstrategyTurism.Data.Features.Hotels;
using TestEstrategyTurism.Domain.Features;
using TestEstrategyTurism.Domain.Features.Hotels;

namespace TestingStrategyTurism.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelAppService _hotelAppService;
        private IRepositoryBase<Hotel> _repositoryBase;
        private readonly TestingEstrategyTurismDbContext _context;
        public HotelsController(TestingEstrategyTurismDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Hotel>(_context);
            _hotelAppService = new HotelAppService(_repositoryBase);
        }

        // GET api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get()
        {
            return await _hotelAppService.GetHotels();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
