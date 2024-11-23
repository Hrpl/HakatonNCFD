using Microsoft.AspNetCore.Mvc;
using SportEvents.Infrastructure.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using SportEvents.Domain.Common.Response;
using SportEvents.Domain.Models;
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
        public async Task<ActionResult<IEnumerable<SportEventResponse>>> Get([FromQuery] string jwt)
        {
            var id = await DecodJwt(jwt);

            var response = await _favouritesEventService.GetAnyFavouritesEvent(id);

            if (response != null) return Ok(response);
            else return BadRequest();
        }

        // POST api/<FavouritesEventController>
        [HttpPost]
        public async void Post(FavouritesEventModel model)
        {
            await _favouritesEventService.CreateFavouritesEvent(model);
            Created();
        }

        private static async Task<int> DecodJwt(string accessToken)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(accessToken);

                var claims = jwtToken.Payload;
                foreach (var claim in claims)
                {
                    if (claim.Key == "userId") return Convert.ToInt32( claim.Value);
                }

                throw new InvalidOperationException("UserId not found in the token");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error decoding JWT: {ex.Message}", ex);
            }
        }
    }
}
