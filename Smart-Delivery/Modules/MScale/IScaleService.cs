using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MScale
{
    public interface IScaleService : ITransientService
    {
        ScaleEntity Create(ScaleEntity scaleEntity);
        ScaleEntity Get(Guid scaleId);
        List<ScaleEntity> Get();
        ScaleEntity Update(Guid scaleId, ScaleEntity scaleEntity);
        bool Delete(Guid scaleId);

    }
}
