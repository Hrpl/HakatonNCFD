using Microsoft.AspNetCore.Mvc;
using SportEvents.Domain.Common.Request;
using SportEvents.Domain.Common.Response;
using SportEvents.Domain.Models;
using SportEvents.Infrastructure.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private readonly ISportEventService _sportEventService;

        public SportEventController(ISportEventService sportEventService)
        {
            _sportEventService = sportEventService;
        }



        // GET: api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<SportEventResponse>>> Get(PaginateRequest req)
        {
            var response = await _sportEventService.GetAllSportEventsAsync(req);
            if (response == null) return BadRequest(response);
            return Ok(response);
        }

    }
}
