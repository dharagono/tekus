using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class VendorCustom
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Value { get; set; }
        public int IdVendor { get; set; }
        public virtual Vendor IdNavigation { get; set; } = null!;

    }
}
