using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDelivery.Modules.MShipper
{
    [Route("api/Customer")]
    public class CustomerController : CommonController
    {
        private ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route(""), HttpPost]
        public CustomerEntity Create([FromBody]CustomerEntity customerEntity)
        {
            return customerService.Create(customerEntity);
        }

        [Route("{customerId}"), HttpGet]
        public CustomerEntity Get(Guid customerId)
        {
            return customerService.Get(customerId);
        }

        [Route("{customerId}"), HttpPut]
        public CustomerEntity Update(Guid customerId, [FromBody]CustomerEntity shipperEntity)
        {
            return customerService.Update(customerId, shipperEntity);
        }

        [Route("{customerId}"), HttpDelete]
        public bool Delete(Guid customerId)
        {
            return customerService.Delete(customerId);
        }
    }
}
