using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MScale
{
    public class OlderService : CommonService, IScaleService
    {
        public ScaleEntity Create(ScaleEntity scaleEntity)
        {
            Scale scale = scaleEntity.ToModel();
            smartDeliveryContext.Scale.Add(scale);
            smartDeliveryContext.SaveChanges();
            return scaleEntity;
        }

        public bool Delete(Guid scaleId)
        {
            Scale scale = smartDeliveryContext.Scale.Where(m => m.Id == scaleId)
               .Include(u => u.Goods)
               .FirstOrDefault();
            if (scale == null)
            {
                throw new BadRequestException("Scale khong ton tai");
            }
            smartDeliveryContext.Scale.Remove(scale);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public ScaleEntity Get(Guid scaleId)
        {
            Scale scale = smartDeliveryContext.Scale.Where(m => m.Id == scaleId)
              .Include(u => u.Goods)
              .FirstOrDefault();
            if (scale == null)
            {
                throw new BadRequestException("Scale khong ton tai");
            }
            return new ScaleEntity(scale, scale.Goods);
        }

        public List<ScaleEntity> Get()
        {
            IQueryable<Scale> scales = smartDeliveryContext.Scale
                 .Include(u => u.Goods);
            return scales.Select(u => new ScaleEntity(u, u.Goods)).ToList();
        }

        public ScaleEntity Update(Guid scaleId, ScaleEntity scaleEntity)
        {
            Scale scale = smartDeliveryContext.Scale.Where(m => m.Id == scaleId)
              .Include(u => u.Goods)
              .FirstOrDefault();
            if (scale == null)
            {
                throw new BadRequestException("Scale khong ton tai");
            }
            scaleEntity.ToModel(scale);
            smartDeliveryContext.Scale.Update(scale);
            smartDeliveryContext.SaveChanges();
            return scaleEntity;
        }
    }
}
