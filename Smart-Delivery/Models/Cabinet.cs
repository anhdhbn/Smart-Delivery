using System;
using System.Collections.Generic;

namespace Smart-Delivery.Models
{
    public partial class Cabinet
    {
        public Guid Id { get; set; }
        public int? Status { get; set; }
        public Guid? GoodsId { get; set; }
        public Guid Code { get; set; }
        public Guid? LocationId { get; set; }
        public string Name { get; set; }

        public Good Goods { get; set; }
        public Repository Location { get; set; }
    }
}
