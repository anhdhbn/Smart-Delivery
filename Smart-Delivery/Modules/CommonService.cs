using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules
{
    public class CommonService
    {
        protected SmartDeliveryContext smartDeliveryContext;
        public CommonService()
        {
            smartDeliveryContext = new SmartDeliveryContext();
        }
    }
}
