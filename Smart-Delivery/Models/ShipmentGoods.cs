using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class ShipmentGoods
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }
        public Guid GoodsId { get; set; }

        public Goods Goods { get; set; }
        public Shipment Shipment { get; set; }
    }
}
