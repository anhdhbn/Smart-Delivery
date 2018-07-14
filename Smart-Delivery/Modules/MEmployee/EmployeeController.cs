using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MEmployee
{
    [Route("api/Employee")]
    public class EmployeeController : CommonController
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [Route(""), HttpPost]
        public EmployeeEntity Create([FromBody]EmployeeEntity employeeEntity)
        {
            return employeeService.Create(employeeEntity);
        }

        [Route(""), HttpGet]
        public List<EmployeeEntity> Get()
        {
            return employeeService.Get();
        }
        [Route("{employeeId}"), HttpGet]
        public EmployeeEntity Get(Guid employeeId)
        {
            return employeeService.Get(employeeId);
        }

        [Route("{employeeId}"), HttpPut]
        public EmployeeEntity Update(Guid employeeId, [FromBody]EmployeeEntity employeeEntity)
        {
            return employeeService.Update(employeeId, employeeEntity);
        }

        [Route("{employeeId}"), HttpGet]
        public bool Delete(Guid employeeId)
        {
            return employeeService.Delete(employeeId);
        }
    }
}
