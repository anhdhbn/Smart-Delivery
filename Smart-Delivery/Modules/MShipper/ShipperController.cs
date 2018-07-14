using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartDelivery.Modules.MCustomer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDelivery.Modules.MShipper
{
    [Route("api/Customer")]
    public class CustomerController : CommonController
    {
        private IShipperService shipperrService;
        public CustomerController(IShipperService shipperrService)
        {
            this.shipperrService = shipperrService;
        }

        [Route(""), HttpPost]
        public ShipperEntity Create([FromBody]ShipperEntity customerEntity)
        {
            return shipperrService.Create(customerEntity);
        }

        [Route("{customerId}"), HttpGet]
        public ShipperEntity Get(Guid customerId)
        {
            return shipperrService.Get(customerId);
        }

        [Route("{customerId}"), HttpPut]
        public ShipperEntity Update(Guid customerId, [FromBody]ShipperEntity shipperEntity)
        {
            return shipperrService.Update(customerId, shipperEntity);
        }

        [Route("{customerId}"), HttpDelete]
        public bool Delete(Guid customerId)
        {
            return shipperrService.Delete(customerId);
        }
    }
}
