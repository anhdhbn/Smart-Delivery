using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipper
{
    public interface IShipperService : ITransientService
    {

        ShipperEntity Get(Guid ShipperId);
        List<ShipperEntity> Get();
        ShipperEntity Create(ShipperEntity ShipmentGoodEntity);
        ShipperEntity Update(Guid ShipperId, ShipperEntity ShipperEntity);
        bool Delete(Guid ShipperId);
    }
}
