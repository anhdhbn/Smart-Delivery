using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDelivery.Modules.MShipper
{
    [Route("api/Shipper")]
    public class CustomerController : CommonController
    {
        private IShipperService shipperService;
        public CustomerController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }

        [Route(""), HttpPost]
        public ShipperEntity Create([FromBody]ShipperEntity customerEntity)
        {
            return shipperService.Create(customerEntity);
        }

        [Route("{shipperId}"), HttpGet]
        public ShipperEntity Get(Guid shipperId)
        {
            return shipperService.Get(shipperId);
        }

        [Route("{shipperId}"), HttpPut]
        public ShipperEntity Update(Guid shipperId, [FromBody]ShipperEntity shipperEntity)
        {
            return shipperService.Update(shipperId, shipperEntity);
        }

        [Route("{customerId}"), HttpDelete]
        public bool Delete(Guid shipperId)
        {
            return shipperService.Delete(shipperId);
        }
    }
}
