using Microsoft.AspNetCore.Mvc;
using Tekus.DTO;
using Tekus.Models;
using Tekus.Services;

namespace Tekus.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly IVendorServices _vendorServices;

        public VendorController(ILogger<DefaultController> logger, IVendorServices vendorServices)
        {
            _logger = logger;
            _vendorServices = vendorServices;
        }

        [HttpGet("GetAllVendors")]
        public async Task<IActionResult> GetAllVendors()
        {
            try
            {
                var result = await _vendorServices.GetAllVendors();
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

        [HttpGet("GetVendor/{id}")]
        public async Task<IActionResult> GetVendor([FromRoute] int id)
        {
            try
            {
                var result = await _vendorServices.GetByIdAsync(id);
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

        [HttpPost("CreateVendor")]
        public async Task<IActionResult> CreateVendor([FromBody] RequestVendor vendor)
        {
            try
            {
                Vendor model = new()
                {
                    Name = vendor.Name,
                    Nit = vendor.Nit,
                    Email = vendor.Email
                };
                if(await _vendorServices.CreateVendor(model))
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

        [HttpPut("UpdateVendor")]
        public IActionResult UpdateVendor([FromBody] RequestVendor vendor)
        {
            try
            {
                Vendor model = new()
                {
                    Id=vendor.Id,
                    Name = vendor.Name,
                    Nit = vendor.Nit,
                    Email = vendor.Email
                };
                if (_vendorServices.UpdateVendor(model))
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
