using Tekus.Models;

namespace Tekus.DTO
{
    public class ResponseServicePortafolio
    {
        public int Id { get; set; }
        public string? ServiceName { get; set; }=null;
        public string? VendorName { get; set;} =null;
        public string? CountryCode { get; set; } =null;
        public string? Status { get; set; } =null;
    }
}