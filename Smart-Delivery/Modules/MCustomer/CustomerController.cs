using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDelivery.Modules.MCustomer
{
    [Route("api/Customer")]
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

        [Route("{customerId}"), HttpGet]
        public CustomerEntity Get(Guid customerId)
        {
            return shipperService.Get(customerId);
        }

        [Route(""), HttpGet]
        public List<CustomerEntity> Get()
        {
            return shipperService.Get();
        }

        [Route("{customerId}"), HttpPut]
        public CustomerEntity Update(Guid customerId, [FromBody]CustomerEntity shipperEntity)
        {
            return shipperService.Update(customerId, shipperEntity);
        }

        [Route("{customerId}"), HttpDelete]
        public bool Delete(Guid customerId)
        {
            return shipperService.Delete(customerId);
        }
    }
}
