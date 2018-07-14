using System;
using System.Collections.Generic;

namespace Smart-Delivery.Models
{
    public partial class ShipmentGood
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }
        public Guid GoodsId { get; set; }

        public Good Goods { get; set; }
        public Shipment Shipment { get; set; }
    }
}
