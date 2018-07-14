using System;
using System.Collections.Generic;

namespace Smart-Delivery.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentGoods = new HashSet<ShipmentGood>();
        }

        public Guid Id { get; set; }
        public Guid ShipperId { get; set; }
        public string Name { get; set; }

        public Shipper Shipper { get; set; }
        public ICollection<ShipmentGood> ShipmentGoods { get; set; }
    }
}
