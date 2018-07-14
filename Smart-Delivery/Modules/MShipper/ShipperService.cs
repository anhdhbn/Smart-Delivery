using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using SmartDelivery.Modules.MShipment;
using SmartDelivery.Modules.MShipmentGood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipper
{
    public class ShipperService : CommonService, IShipperService
    {
        public ShipperEntity Create(ShipperEntity shipperEntity)
        {
            Shipper shipper = shipperEntity.ToModel();
            User User = new User();
            User.Id = shipperEntity.Id;
            User.Username = shipperEntity.Name;
            User.Password = "12345abcd";
            smartDeliveryContext.User.Add(User);
            smartDeliveryContext.Shipper.Add(shipper);
            smartDeliveryContext.SaveChanges();
            return shipperEntity;
        }

        public bool Delete(Guid ShipperId)
        {
            Shipper shipper = smartDeliveryContext.Shipper.Where(m => m.Id == ShipperId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            User user = smartDeliveryContext.User.Where(m => m.Id == ShipperId).FirstOrDefault();
            if (shipper == null)
            {
                throw new BadRequestException("Shipper khong ton tai");
            }
            smartDeliveryContext.User.Remove(user);
            smartDeliveryContext.Shipper.Remove(shipper);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public ShipperEntity Get(Guid ShipperId)
        {
            Shipper shipper = smartDeliveryContext.Shipper.Where(m => m.Id == ShipperId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            if (shipper == null)
            {
                throw new BadRequestException("Shipper khong ton tai");
            }
            return new ShipperEntity(shipper, shipper.IdNavigation);
        }

        public List<ShipperEntity> Get()
        {
            IQueryable<Shipper> shippers = smartDeliveryContext.Shipper
            .Include(m => m.IdNavigation);
            return shippers.Select(u => new ShipperEntity(u,u.IdNavigation)).ToList();
        }

        public ShipperEntity Update(Guid ShipperId, ShipperEntity ShipperEntity)
        {
            Shipper shipper = smartDeliveryContext.Shipper.Where(m => m.Id == ShipperId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            if (shipper == null)
            {
                throw new BadRequestException("Shipper khong ton tai");
            }
            ShipperEntity.ToModel(shipper);
            smartDeliveryContext.Shipper.Update(shipper);
            smartDeliveryContext.SaveChanges();
            return ShipperEntity;
        }
    }
}
