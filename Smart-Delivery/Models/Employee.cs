﻿using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Employee
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Display { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }

        public User IdNavigation { get; set; }
    }
}
