using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Cabinet
    {
        public Guid Id { get; set; }
        public bool? IsOpended { get; set; }
        public Guid? GoodsId { get; set; }
        public string Code { get; set; }
        public Guid? LocationId { get; set; }
        public string Name { get; set; }
        public bool? IsHadGoods { get; set; }
        public bool? IsRecievieCabinet { get; set; }

        public Goods Goods { get; set; }
        public Repositories Location { get; set; }
    }
}
