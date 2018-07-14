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
            smartDeliveryContext.User.Add(User);
            smartDeliveryContext.Customer.Add(customer);
            smartDeliveryContext.SaveChanges();
            return new CustomerEntity(customer);
        }

        public bool Delete(Guid CustomerId)
        {
            Customer customer = smartDeliveryContext.Customer.Where(m => m.Id == CustomerId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            User user = smartDeliveryContext.User.Where(m => m.Id == CustomerId).FirstOrDefault();
            if (customer == null)
            {
                throw new BadRequestException("Customer khong ton tai");
            }
            smartDeliveryContext.User.Remove(user);
            smartDeliveryContext.Customer.Remove(customer);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public CustomerEntity Get(Guid CustomerId)
        {
            Customer customer = smartDeliveryContext.Customer.Where(m => m.Id == CustomerId)
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
            IQueryable<Customer> customers = smartDeliveryContext.Customer
            .Include(m => m.IdNavigation);
            return customers.Select(u => new CustomerEntity(u,u.IdNavigation)).ToList();
        }

        public CustomerEntity Update(Guid CustomerId, CustomerEntity customerEntity)
        {
            Customer customer = smartDeliveryContext.Customer.Where(m => m.Id == CustomerId)
               .Include(u => u.IdNavigation)
               .FirstOrDefault();
            if (customer == null)
            {
                throw new BadRequestException("Customer khong ton tai");
            }
            customerEntity.ToModel(customer);
            smartDeliveryContext.Customer.Update(customer);
            smartDeliveryContext.SaveChanges();
            return customerEntity;
        }
    }
}
