using System;
using System.Collections.Generic;

namespace SmartDelivery.Models
{
    public partial class Repositories
    {
        public Repositories()
        {
            Cabinet = new HashSet<Cabinet>();
        }

        public Guid Id { get; set; }
        public string Location { get; set; }

        public ICollection<Cabinet> Cabinet { get; set; }
    }
}
