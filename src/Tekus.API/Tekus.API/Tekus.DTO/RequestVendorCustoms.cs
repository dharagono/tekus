namespace Tekus.DTO
{
    public class RequestVendorCustoms
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Value { get; set; }
        public int IdVendor { get; set; }
    }
}
