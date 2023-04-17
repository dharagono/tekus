using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class ServicePortafolio
    {
        public int Id { get; set; }
        public int IdVendor { get; set; }
        public int IdService { get; set; }
        public int IdCountry { get; set; }
        public bool? Status { get; set; }

        public virtual Country IdCountryNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
        public virtual Vendor IdVendorNavigation { get; set; } = null!;
    }
}
