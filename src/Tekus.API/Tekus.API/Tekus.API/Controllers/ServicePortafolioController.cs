using Microsoft.AspNetCore.Mvc;
using Tekus.DTO;
using Tekus.Models;
using Tekus.Services;

namespace Tekus.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicePortafolioController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly IServicePortafolioServices _ServicePortafolioServices;

        public ServicePortafolioController(ILogger<DefaultController> logger, IServicePortafolioServices ServicePortafolioServices)
        {
            _logger = logger;
            _ServicePortafolioServices = ServicePortafolioServices;
        }

        [HttpGet("GetAllServicePortafolio")]
        public async Task<IActionResult> GetAllServicePortafolio()
        {
            try
            {
                var result = await _ServicePortafolioServices.GetAllServicePortafolio();
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

        [HttpGet("GetServicePortafolio/{id}")]
        public async Task<IActionResult> GetServicePortafolio([FromRoute] int id)
        {
            try
            {
                var result = await _ServicePortafolioServices.GetByIdAsync(id);
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

        [HttpPost("CreateServicePortafolio")]
        public async Task<IActionResult> CreateServicePortafolio([FromBody] RequestServicePortafolio servicePortafolio)
        {
            try
            {
                ServicePortafolio model = new()
                {
                    Id=0,
                    IdVendor = servicePortafolio.VendorId,
                    IdService=servicePortafolio.ServiceId,
                    IdCountry=servicePortafolio.CountryId,
                    Status=servicePortafolio.Status
                };
                if(await _ServicePortafolioServices.CreateServicePortafolio(model))
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

        [HttpPut("UpdateServicePortafolio")]
        public IActionResult UpdateServicePortafolio([FromBody] RequestServicePortafolio servicePortafolio)
        {
            try
            {
                ServicePortafolio model = new()
                {
                    Id=servicePortafolio.Id,
                    IdVendor = servicePortafolio.VendorId,
                    IdService = servicePortafolio.ServiceId,
                    IdCountry = servicePortafolio.CountryId,
                    Status = servicePortafolio.Status
                };
                if (_ServicePortafolioServices.UpdateServicePortafolio(model))
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

        [HttpGet("GetByVendorId/{id}")]
        public async Task<IActionResult> GetByVendorId([FromRoute] int id)
        {
            try
            {
                var result = await _ServicePortafolioServices.GetByVendorId(id);
                if (result != null)
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

        [HttpGet("GetByServiceId/{id}")]
        public async Task<IActionResult> GetByServiceId([FromRoute] int id)
        {
            try
            {
                var result = await _ServicePortafolioServices.GetByServiceId(id);
                if (result != null)
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

        [HttpGet("GetByCountryId/{id}")]
        public async Task<IActionResult> GetByCountryId([FromRoute] int id)
        {
            try
            {
                var result = await _ServicePortafolioServices.GetByCountryId(id);
                if (result != null)
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
    }
}
