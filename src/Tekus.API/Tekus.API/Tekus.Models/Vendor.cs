using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            ServicePortafolios = new HashSet<ServicePortafolio>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual VendorCustom? VendorCustom { get; set; }
        public virtual ICollection<ServicePortafolio> ServicePortafolios { get; set; }
    }
}
