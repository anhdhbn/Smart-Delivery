using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipmentGood
{
    public interface IShipmentGoodService : ITransientService
    {
        ShipmentGoodEntity Get(Guid ShipmentGoodId);
        List<ShipmentGoodEntity> Get();
        ShipmentGoodEntity Create(ShipmentGoodEntity ShipmentGoodEntity);
        ShipmentGoodEntity Update(Guid ShipmentGoodId, ShipmentGoodEntity ShipmentGoodEntity);
        bool Delete(Guid ShipmentGoodId);

    }
}
