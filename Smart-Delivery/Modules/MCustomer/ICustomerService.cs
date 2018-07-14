using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MCustomer
{
    public interface ICustomerService : ITransientService
    {

        CustomerEntity Get(Guid CustomerId);
        List<CustomerEntity> Get();
        CustomerEntity Create(CustomerEntity customerEntity);
        CustomerEntity Update(Guid CustomerId, CustomerEntity customerEntity);
        bool Delete(Guid CustomerId);
    }
}
