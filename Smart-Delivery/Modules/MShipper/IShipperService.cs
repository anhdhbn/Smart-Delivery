using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipper
{
    public interface ICustomerService : ITransientService
    {

        CustomerEntity Get(Guid ShipperId);
        List<CustomerEntity> Get();
        CustomerEntity Create(CustomerEntity ShipmentGoodEntity);
        CustomerEntity Update(Guid ShipperId, CustomerEntity ShipperEntity);
        bool Delete(Guid ShipperId);
    }
}
