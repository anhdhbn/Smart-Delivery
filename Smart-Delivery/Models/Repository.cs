using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Repository
    {
        public Repository()
        {
            Cabinets = new HashSet<Cabinet>();
        }

        public Guid Id { get; set; }
        public string Location { get; set; }

        public ICollection<Cabinet> Cabinets { get; set; }
    }
}
