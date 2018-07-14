using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MCabinet
{
    public interface ICabinetService : ITransientService
    {
        CabinetEntity Create(CabinetEntity cabinetEntity);
        CabinetEntity Get(Guid cabinetId);
        List<CabinetEntity> Get();
        CabinetEntity Update(Guid scaleId, CabinetEntity cabinetEntity);
        bool Delete(Guid scaleId);

    }
}
