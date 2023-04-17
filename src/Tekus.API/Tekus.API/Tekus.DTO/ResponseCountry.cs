using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class ResponseCountry
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
