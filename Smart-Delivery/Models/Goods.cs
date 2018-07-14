using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Goods
    {
        public Goods()
        {
            Cabinet = new HashSet<Cabinet>();
            Scale = new HashSet<Scale>();
            ShipmentGoods = new HashSet<ShipmentGoods>();
        }

        public Guid Id { get; set; }
        public Guid? IdReceiver { get; set; }
        public Guid? IdSender { get; set; }
        public double? Weight { get; set; }
        public string Name { get; set; }

        public ICollection<Cabinet> Cabinet { get; set; }
        public ICollection<Scale> Scale { get; set; }
        public ICollection<ShipmentGoods> ShipmentGoods { get; set; }
    }
}
