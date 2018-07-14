using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Admin
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public int? Role { get; set; }

        public User IdNavigation { get; set; }
    }
}
