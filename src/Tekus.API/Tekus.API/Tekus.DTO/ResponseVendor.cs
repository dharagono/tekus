using Tekus.Models;

namespace Tekus.DTO
{
    public class ResponseVendor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}