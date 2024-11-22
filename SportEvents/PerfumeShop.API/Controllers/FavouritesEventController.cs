using Microsoft.AspNetCore.Mvc;
using SportEvents.Domain.Common.Request;
using SportEvents.Infrastructure.Services.Interfaces;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
using SportEvents.Domain.Common.Response;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesEventController : ControllerBase
    {
        private readonly IFavouritesEventService _favouritesEventService;

        public FavouritesEventController(IFavouritesEventService favouritesEventService)
        {
            _favouritesEventService = favouritesEventService;
        }

        // GET: api/<FavouritesEventController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportEventResponse>>> Get(FavouritesEventRequest req)
        {
            var id = await DecodJwt(req.JWT);

            var response = _favouritesEventService.GetAnyFavouritesEvent(id);

            if (response != null) return Ok(response);
            else return BadRequest();
        }

        // POST api/<FavouritesEventController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        private static async Task<int> DecodJwt(string accessToken)
        {
            var payload = accessToken.Split(".")[1];

            try
            {
                byte[] bytes = Convert.FromBase64String(payload);

                // Получение строки из массива байт
                var jsonString = Encoding.UTF8.GetString(bytes);

                JObject jsonObject = JObject.Parse(jsonString);
                int idValue = (int)jsonObject["id"];
                return idValue;
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error decoding JWT: {ex.Message}", ex);
            }
        }
    }
}
