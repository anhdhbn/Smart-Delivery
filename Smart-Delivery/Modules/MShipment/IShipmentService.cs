using SmartDelivery.Modules.MShipment;
using SmartDelivery.Modules.MShipmentGood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MShipment
{
    public interface IShipmentService : ITransientService
    {
        ShipmentEntity Get(Guid ShipmentId);
        List<ShipmentEntity> Get();
        ShipmentEntity Create(ShipmentEntity ShipmentEntity);
        ShipmentEntity Update(Guid ShipmentId, ShipmentEntity ShipmentEntity);
        bool Delete(Guid ShipmentId);
    }
}
