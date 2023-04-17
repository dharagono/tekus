using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class Country
    {
        public Country()
        {
            ServicePortafolios = new HashSet<ServicePortafolio>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public virtual ICollection<ServicePortafolio> ServicePortafolios { get; set; }
    }
}
