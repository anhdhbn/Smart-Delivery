using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules
{
    public class CommonEntity
    {
        
    }

    [Flags]
    public enum ROLES
    {
        USER = 1,
        CUSTOMER = 2,
        Employee = 4,
        Shipper = 8,
        ADMIN = 16
    }
}
