using SmartDelivery.Models;
using SmartDelivery.Modules.MShipment;
using SmartDelivery.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MCustomer
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Display { get; set; }
        public string Picture { get; set; }
        public string FacebookId { get; set; }
        public string FacebookEmail { get; set; }
        public string GoogleId { get; set; }
        public string GoogleEmail { get; set; }
        public long? Cx { get; set; }

        public UserEntity IdNavigation { get; set; }
        public CustomerEntity(Customer customer, params object[] args)
        {
            this.Id = customer.Id;
            this.Password = customer.Password;
            this.Username = customer.Username;
            this.Display = customer.Display;
            this.Picture = customer.Picture;
            this.FacebookEmail = customer.FacebookEmail;
            this.FacebookId = customer.FacebookId;
            this.GoogleEmail = customer.GoogleEmail;
            this.GoogleId = customer.GoogleId;
            this.Cx = customer.Cx;
            foreach(var arg in args)
            {
                if (arg is User) this.IdNavigation = customer.IdNavigation == null ? null : new UserEntity(arg as User);
            }
        }

        public Customer ToModel(Customer customer = null)
        {
            if(customer == null)
            {
                customer = new Customer();
                customer.Id = new Guid();
            }
            customer.Password = this.Password;
            customer.Username = this.Username;
            customer.Picture = this.Picture;
            customer.Display = this.Display;
            customer.FacebookEmail = this.FacebookEmail;
            customer.FacebookId = this.FacebookId;
            customer.GoogleEmail = this.GoogleEmail;
            customer.GoogleId = this.GoogleId;
            customer.Cx = this.Cx;
            return customer;
        }
    }
}
