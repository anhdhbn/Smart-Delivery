using System;
using System.Collections.Generic;

namespace Smart-Delivery.Models
{
    public partial class Customer
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

        public User IdNavigation { get; set; }
    }
}
