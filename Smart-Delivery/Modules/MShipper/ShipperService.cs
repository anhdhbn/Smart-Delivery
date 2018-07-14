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
    public class CustomerService : CommonService, ICustomerService
    {
        public CustomerEntity Create(CustomerEntity shipperEntity)
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

        public CustomerEntity Get(Guid ShipperId)
        {
            Shipper shipper = smartDeliveryContext.Shipper.Where(m => m.Id == ShipperId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            if (shipper == null)
            {
                throw new BadRequestException("Shipper khong ton tai");
            }
            return new CustomerEntity(shipper, shipper.IdNavigation);
        }

        public List<CustomerEntity> Get()
        {
            IQueryable<Shipper> shippers = smartDeliveryContext.Shipper
            .Include(m => m.IdNavigation);
            return shippers.Select(u => new CustomerEntity(u,u.IdNavigation)).ToList();
        }

        public CustomerEntity Update(Guid ShipperId, CustomerEntity ShipperEntity)
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
