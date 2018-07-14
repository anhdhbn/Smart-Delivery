using SmartDelivery.Models;
using SmartDelivery.Modules.MGoods;
using SmartDelivery.Modules.MShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipmentGood
{
    public class ShipmentGoodEntity
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }
        public Guid GoodsId { get; set; }

        public GoodsEntity Goods { get; set; }
        public ShipmentEntity Shipment { get; set; }

        public ShipmentGoodEntity(ShipmentGood shipmentGood, params object[] args)
        {
            this.Id = shipmentGood.Id;
            this.ShipmentId = shipmentGood.ShipmentId;
            this.GoodsId = shipmentGood.GoodsId;
            foreach(var arg in args)
            {
                if (arg is Shipment) this.Shipment = shipmentGood.Shipment == null ? null : new ShipmentEntity(arg as Shipment);
                if (arg is Good) this.Goods = shipmentGood.Goods == null ? null : new GoodsEntity(arg as Good);
            }
        }

        public ShipmentGood ToModel(ShipmentGood shipmentGood = null)
        {
            if(shipmentGood == null)
            {
                shipmentGood = new ShipmentGood();
                shipmentGood.Id = new Guid();
            }
            shipmentGood.GoodsId = this.GoodsId;
            shipmentGood.ShipmentId = this.ShipmentId;
            return shipmentGood;
        }
    }
}
