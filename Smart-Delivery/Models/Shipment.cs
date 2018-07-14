using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentGoods = new HashSet<ShipmentGoods>();
        }

        public Guid Id { get; set; }
        public Guid ShipperId { get; set; }
        public string Name { get; set; }

        public Shipper Shipper { get; set; }
        public ICollection<ShipmentGoods> ShipmentGoods { get; set; }
    }
}
