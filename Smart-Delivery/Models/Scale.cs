using System;
using System.Collections.Generic;

namespace Smart-Delivery.Models
{
    public partial class Scale
    {
        public Guid Id { get; set; }
        public Guid GoodsId { get; set; }
        public double Weight { get; set; }

        public Good Goods { get; set; }
    }
}
