using SmartDelivery.Models;
using SmartDelivery.Modules.MShipmentGood;
using SmartDelivery.Modules.MShipper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipment
{
    public class ShipmentEntity
    {
        public Guid Id { get; set; }
        public Guid ShipperId { get; set; }
        public string Name { get; set; }
        public CustomerEntity ShipperEntity { get; set; }
        public ICollection<ShipmentGoodEntity> ShipmentGoodEntities { get; set; }
        public ShipmentEntity(Shipment Shipment, params object[] args)
        {
            this.Id = Shipment.Id;
            this.ShipperId = Shipment.ShipperId;
            this.Name = Shipment.Name;
            foreach (var arg in args)
            {
                if (arg is Shipper) this.ShipperEntity = Shipment.Shipper == null ? null : new CustomerEntity(arg as Shipper);
                if (arg is ICollection<ShipmentGoods>)
                    this.ShipmentGoodEntities = (arg as ICollection<ShipmentGoods>).Select(ir => new ShipmentGoodEntity(ir)).ToList();
            }
        }

        public Shipment ToModel(Shipment shipment = null)
        {
            if (shipment == null)
            {
                shipment = new Shipment();
                shipment.Id = new Guid();
            }
            shipment.Name = this.Name;
            shipment.ShipperId = this.ShipperId;
            return shipment;
        }
    }
}
