using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Good
    {
        public Good()
        {
            Cabinets = new HashSet<Cabinet>();
            Scales = new HashSet<Scale>();
            ShipmentGoods = new HashSet<ShipmentGood>();
        }

        public Guid Id { get; set; }
        public Guid? IdReceiver { get; set; }
        public Guid? IdSender { get; set; }
        public double? Weight { get; set; }
        public string Name { get; set; }

        public ICollection<Cabinet> Cabinets { get; set; }
        public ICollection<Scale> Scales { get; set; }
        public ICollection<ShipmentGood> ShipmentGoods { get; set; }
    }
}
