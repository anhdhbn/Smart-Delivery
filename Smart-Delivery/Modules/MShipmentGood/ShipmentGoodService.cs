using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using SmartDelivery.Modules.MShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipmentGood
{
    public class ShipmentGoodService : CommonService, IShipmentGoodService
    {
        public ShipmentGoodEntity Create(ShipmentGoodEntity ShipmentGoodEntity)
        {
            ShipmentGoods shipmentGood = ShipmentGoodEntity.ToModel();
            smartDeliveryContext.ShipmentGoods.Add(shipmentGood);
            smartDeliveryContext.SaveChanges();
            return ShipmentGoodEntity;
        }

        public bool Delete(Guid ShipmentGoodId)
        {
            ShipmentGoods shipmentGood = smartDeliveryContext.ShipmentGoods.Where(m => m.Id == ShipmentGoodId)
                .Include(u => u.Goods)
                .Include(u => u.Shipment)
                .FirstOrDefault();
            if (shipmentGood == null)
            {
                throw new BadRequestException("ShipmentGood khong ton tai");
            }
            smartDeliveryContext.ShipmentGoods.Remove(shipmentGood);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public ShipmentGoodEntity Get(Guid ShipmentGoodId)
        {
            ShipmentGoods shipmentGood = smartDeliveryContext.ShipmentGoods.Where(m => m.Id == ShipmentGoodId)
                 .Include(u => u.Goods)
                 .Include(u => u.Shipment)
                 .FirstOrDefault();
            if (shipmentGood == null)
            {
                throw new BadRequestException("ShipmentGood khong ton tai");
            }
            return new ShipmentGoodEntity(shipmentGood, shipmentGood.Goods, shipmentGood.Shipment);
        }

        public List<ShipmentGoodEntity> Get()
        {
            IQueryable<ShipmentGoods> shipmentGoods = smartDeliveryContext.ShipmentGoods
            .Include(m => m.Goods)
            .Include(m => m.Shipment);
            return shipmentGoods.Select(u => new ShipmentGoodEntity(u, u.Goods, u.Shipment)).ToList();
        }

        public ShipmentGoodEntity Update(Guid ShipmentGoodId, ShipmentGoodEntity ShipmentGoodEntity)
        {
            ShipmentGoods shipmentGood = smartDeliveryContext.ShipmentGoods.Where(m => m.Id == ShipmentGoodId)
                .Include(u => u.Goods)
                .Include(u => u.Shipment)
                .FirstOrDefault();
            if (shipmentGood == null)
            {
                throw new BadRequestException("ShipmentGood khong ton tai");
            }
            ShipmentGoodEntity.ToModel(shipmentGood);
            smartDeliveryContext.ShipmentGoods.Update(shipmentGood);
            smartDeliveryContext.SaveChanges();
            return ShipmentGoodEntity;
        }
    }
}
