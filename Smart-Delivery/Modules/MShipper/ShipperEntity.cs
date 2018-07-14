using SmartDelivery.Models;
using SmartDelivery.Modules.MShipment;
using SmartDelivery.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipper
{
    public class ShipperEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }

        public UserEntity IdNavigation { get; set; }
        public ICollection<ShipmentEntity> Shipments { get; set; }
        public ShipperEntity() { }
        public ShipperEntity(Shipper shipper, params object[] args)
        {
            this.Id = shipper.Id;
            this.Name = shipper.Name;
            this.Age = shipper.Age;
            this.Phone = shipper.Phone;
            foreach(var arg in args)
            {
                if (arg is User) this.IdNavigation = shipper.IdNavigation == null ? null : new UserEntity(arg as User);
                if (arg is ICollection<Shipment>) this.Shipments = (arg as ICollection<Shipment>).Select(ir => new ShipmentEntity(ir)).ToList();
            }
        }

        public Shipper ToModel(Shipper shipper = null)
        {
            if(shipper == null)
            {
                shipper = new Shipper();
                shipper.Id = Guid.NewGuid();
            }
            shipper.IdNavigation.Role = 4;
            shipper.Name = this.Name;
            shipper.Age = this.Age;
            shipper.Phone = this.Phone;
            return shipper;
        }
    }
}
