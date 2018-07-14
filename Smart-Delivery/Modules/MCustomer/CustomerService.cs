using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using SmartDelivery.Modules.MShipment;
using SmartDelivery.Modules.MShipmentGood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MCustomer
{
    public class CustomerService : CommonService, ICustomerService
    {
        public CustomerEntity Create(CustomerEntity customerEntity)
        {
            Customer customer = customerEntity.ToModel();
            User User = new User();
            User.Id = customerEntity.Id;
            User.Username = customerEntity.Username;
            User.Password = customerEntity.Password;
            smartDeliveryContext.Users.Add(User);
            smartDeliveryContext.Customers.Add(customer);
            smartDeliveryContext.SaveChanges();
            return customerEntity;
        }

        public bool Delete(Guid CustomerId)
        {
            Customer customer = smartDeliveryContext.Customers.Where(m => m.Id == CustomerId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            User user = smartDeliveryContext.Users.Where(m => m.Id == CustomerId).FirstOrDefault();
            if (customer == null)
            {
                throw new BadRequestException("Customer khong ton tai");
            }
            smartDeliveryContext.Users.Remove(user);
            smartDeliveryContext.Customers.Remove(customer);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public CustomerEntity Get(Guid CustomerId)
        {
            Customer customer = smartDeliveryContext.Customers.Where(m => m.Id == CustomerId)
              .Include(u => u.IdNavigation)
              .FirstOrDefault();
            if (customer == null)
            {
                throw new BadRequestException("Customer khong ton tai");
            }
            return new CustomerEntity(customer, customer.IdNavigation);
        }

        public List<CustomerEntity> Get()
        {
            IQueryable<Customer> customers = smartDeliveryContext.Customers
            .Include(m => m.IdNavigation);
            return customers.Select(u => new CustomerEntity(u,u.IdNavigation)).ToList();
        }

        public CustomerEntity Update(Guid CustomerId, CustomerEntity customerEntity)
        {
            Customer customer = smartDeliveryContext.Customers.Where(m => m.Id == CustomerId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            if (customer == null)
            {
                throw new BadRequestException("Customer khong ton tai");
            }
            customerEntity.ToModel(customer);
            smartDeliveryContext.Customers.Update(customer);
            smartDeliveryContext.SaveChanges();
            return customerEntity;
        }
    }
}
