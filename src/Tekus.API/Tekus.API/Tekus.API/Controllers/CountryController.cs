using Microsoft.AspNetCore.Mvc;
using Tekus.DTO;
using Tekus.Models;
using Tekus.Services;

namespace Tekus.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly ICountryServices _CountryServices;

        public CountryController(ILogger<DefaultController> logger, ICountryServices CountryServices)
        {
            _logger = logger;
            _CountryServices = CountryServices;
        }

        [HttpGet("GetAllCountrys")]
        public async Task<IActionResult> GetAllCountrys()
        {
            try
            {
                var result = await _CountryServices.GetAllCountrys();
                if (result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("GetCountry/{id}")]
        public async Task<IActionResult> GetCountry([FromRoute] int id)
        {
            try
            {
                var result = await _CountryServices.GetByIdAsync(id);
                if(result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountry([FromBody] RequestCountry country)
        {
            try
            {
                Country model = new()
                {
                    Id = country.Id,
                    Name = country.Name,
                    Code = country.Code
                };
                if (await _CountryServices.CreateCountry(model))
                {
                    return Ok(true);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
