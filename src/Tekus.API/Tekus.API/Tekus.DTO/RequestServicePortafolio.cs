using Tekus.Models;

namespace Tekus.DTO
{
    public class RequestServicePortafolio
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int VendorId { get; set;}
        public int CountryId { get; set; }
        public bool Status { get; set; } = false;
    }
}