﻿using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class Service
    {
        public Service()
        {
            ServicePortafolios = new HashSet<ServicePortafolio>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Hourprice { get; set; }
        public virtual ICollection<ServicePortafolio> ServicePortafolios { get; set; }
    }
}
