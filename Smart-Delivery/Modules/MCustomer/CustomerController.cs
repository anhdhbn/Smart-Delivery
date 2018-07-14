using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDelivery.Modules.MCustomer
{
    [Route("api/Shipper")]
    public class CustomerController : CommonController
    {
        private ICustomerService shipperService;
        public CustomerController(ICustomerService shipperService)
        {
            this.shipperService = shipperService;
        }

        [Route(""), HttpPost]
        public CustomerEntity Create([FromBody]CustomerEntity shipperEntity)
        {
            return shipperService.Create(shipperEntity);
        }

        [Route("{shipperId}"), HttpGet]
        public CustomerEntity Get(Guid shipperId)
        {
            return shipperService.Get(shipperId);
        }

        [Route("{shipperId}"), HttpPut]
        public CustomerEntity Update(Guid shipperId, [FromBody]CustomerEntity shipperEntity)
        {
            return shipperService.Update(shipperId, shipperEntity);
        }

        [Route("{shipperId}"), HttpDelete]
        public bool Delete(Guid shipperId)
        {
            return shipperService.Delete(shipperId);
        }
    }
}
