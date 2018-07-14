using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using SmartDelivery.Modules.MShipment;
using SmartDelivery.Modules.MShipmentGood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipment
{
    public class ShipmentService : CommonService, IShipmentService
    {
        public ShipmentEntity Create(ShipmentEntity ShipmentEntity)
        {
            Shipment shipment = ShipmentEntity.ToModel();
            smartDeliveryContext.Shipment.Add(shipment);
            smartDeliveryContext.SaveChanges();
            return ShipmentEntity;
        }

        public bool Delete(Guid ShipmentId)
        {
            Shipment shipment = smartDeliveryContext.Shipment.Where(m => m.Id == ShipmentId)
               .FirstOrDefault();
            if (shipment == null)
            {
                throw new BadRequestException("Shipment khong ton tai");

            }
            smartDeliveryContext.Shipment.Remove(shipment);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public ShipmentEntity Get(Guid ShipmentId)
        {
            Shipment shipment = smartDeliveryContext.Shipment.Where(m => m.Id == ShipmentId)
                 .Include(m => m.ShipmentGoods)
                 .Include(m => m.Shipper)
                 .FirstOrDefault();
            if (shipment == null)
                throw new BadRequestException("Shipment khong ton tai");
            return new ShipmentEntity(shipment, shipment.Shipper, shipment.ShipmentGoods);
        }

        public List<ShipmentEntity> Get()
        {
            IQueryable<Shipment> shipments = smartDeliveryContext.Shipment
            .Include(m => m.ShipmentGoods)
            .Include(m => m.Shipper);
            return shipments.Select(u => new ShipmentEntity(u, u.Shipper, u.ShipmentGoods)).ToList();
        }

        public ShipmentEntity Update(Guid ShipmentId, ShipmentEntity ShipmentEntity)
        {
            Shipment shipments = smartDeliveryContext.Shipment.Where(m => m.Id == ShipmentId).FirstOrDefault();
            if (shipments == null)
                throw new BadRequestException("Shipment khong ton tai");
            ShipmentEntity.ToModel(shipments);
            smartDeliveryContext.Shipment.Update(shipments);
            smartDeliveryContext.SaveChanges();
            return ShipmentEntity;
        }
    }
}
