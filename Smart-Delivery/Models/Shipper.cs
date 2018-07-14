using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Shipments = new HashSet<Shipment>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }

        public User IdNavigation { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
    }
}
