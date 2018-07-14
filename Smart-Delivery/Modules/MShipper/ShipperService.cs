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
            smartDeliveryContext.Users.Add(User);
            smartDeliveryContext.Shippers.Add(shipper);
            smartDeliveryContext.SaveChanges();
            return shipperEntity;
        }

        public bool Delete(Guid ShipperId)
        {
            Shipper shipper = smartDeliveryContext.Shippers.Where(m => m.Id == ShipperId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            User user = smartDeliveryContext.Users.Where(m => m.Id == ShipperId).FirstOrDefault();
            if (shipper == null)
            {
                throw new BadRequestException("Shipper khong ton tai");
            }
            smartDeliveryContext.Users.Remove(user);
            smartDeliveryContext.Shippers.Remove(shipper);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public CustomerEntity Get(Guid ShipperId)
        {
            Shipper shipper = smartDeliveryContext.Shippers.Where(m => m.Id == ShipperId)
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
            IQueryable<Shipper> shippers = smartDeliveryContext.Shippers
            .Include(m => m.IdNavigation);
            return shippers.Select(u => new CustomerEntity(u,u.IdNavigation)).ToList();
        }

        public CustomerEntity Update(Guid ShipperId, CustomerEntity ShipperEntity)
        {
            Shipper shipper = smartDeliveryContext.Shippers.Where(m => m.Id == ShipperId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            if (shipper == null)
            {
                throw new BadRequestException("Shipper khong ton tai");
            }
            ShipperEntity.ToModel(shipper);
            smartDeliveryContext.Shippers.Update(shipper);
            smartDeliveryContext.SaveChanges();
            return ShipperEntity;
        }
    }
}
