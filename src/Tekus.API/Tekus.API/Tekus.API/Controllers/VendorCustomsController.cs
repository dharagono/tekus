using Microsoft.AspNetCore.Mvc;
using Tekus.DTO;
using Tekus.Models;
using Tekus.Services;

namespace Tekus.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorCustomsController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly IVendorCustomsServices _VendorCustomsServices;

        public VendorCustomsController(ILogger<DefaultController> logger, IVendorCustomsServices VendorCustomsServices)
        {
            _logger = logger;
            _VendorCustomsServices = VendorCustomsServices;
        }

        [HttpGet("GetByVendorId/{id}")]
        public async Task<IActionResult> GetAllVendorCustomss([FromRoute] int id)
        {
            try
            {
                var result = await _VendorCustomsServices.GetByVendorId(id);
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

        [HttpGet("GetVendorCustoms/{id}")]
        public async Task<IActionResult> GetVendorCustoms([FromRoute] int id)
        {
            try
            {
                var result = await _VendorCustomsServices.GetByIdAsync(id);
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

        [HttpPost("CreateVendorCustoms")]
        public async Task<IActionResult> CreateVendorCustoms([FromBody] RequestVendorCustoms vendorCustoms)
        {
            try
            {
                VendorCustom model = new()
                {
                    Id = 0,
                    Name = vendorCustoms.Name,
                    Value = vendorCustoms.Value,
                    IdVendor = vendorCustoms.IdVendor
                };
                if(await _VendorCustomsServices.CreateVendorCustoms(model))
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

        [HttpPut("UpdateVendorCustoms")]
        public IActionResult UpdateVendorCustoms([FromBody] RequestVendorCustoms vendorCustoms)
        {
            try
            {
                VendorCustom model = new()
                {
                    Id = 0,
                    Name = vendorCustoms.Name,
                    Value = vendorCustoms.Value,
                    IdVendor = vendorCustoms.IdVendor
                };
                if (_VendorCustomsServices.UpdateVendorCustoms(model))
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
