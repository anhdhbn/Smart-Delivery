using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Scale
    {
        public Guid Id { get; set; }
        public Guid GoodsId { get; set; }
        public double Weight { get; set; }
        public string Code { get; set; }

        public Goods Goods { get; set; }
    }
}
