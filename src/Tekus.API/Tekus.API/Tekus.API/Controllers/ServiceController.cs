using Microsoft.AspNetCore.Mvc;
using Tekus.DTO;
using Tekus.Models;
using Tekus.Services;

namespace Tekus.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly IServiceServices _serviceServices;

        public ServiceController(ILogger<DefaultController> logger, IServiceServices serviceServices)
        {
            _logger = logger;
            _serviceServices = serviceServices;
        }

        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                var result = await _serviceServices.GetAllServices();
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

        [HttpGet("GetService/{id}")]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            try
            {
                    var result = await _serviceServices.GetByIdAsync(id);
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

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService([FromBody] RequestService service)
        {
            try
            {
                Service model = new()
                {
                    Id=service.Id,
                    Name=service.Name,
                    Hourprice=service.Hourprice
                };
                if (await _serviceServices.CreateService(model))
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

        [HttpPut("UpdateService")]
        public IActionResult UpdateService([FromBody] RequestService service)
        {
            try
            {
                Service model = new()
                {
                    Id = service.Id,
                    Name = service.Name,
                    Hourprice = service.Hourprice
                };
                if (_serviceServices.UpdateService(model))
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
