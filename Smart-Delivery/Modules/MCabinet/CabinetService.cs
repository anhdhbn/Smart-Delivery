using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MCabinet
{
    public class CabinetService : CommonService, ICabinetService
    {
        public CabinetEntity Create(CabinetEntity cabinetEntity)
        {
            Cabinet cabinet = cabinetEntity.ToModel();
            smartDeliveryContext.Cabinets.Add(cabinet);
            smartDeliveryContext.SaveChanges();
            return cabinetEntity;
        }

        public bool Delete(Guid cabinetId)
        {
            Cabinet cabinet = smartDeliveryContext.Cabinets.Where(m => m.Id == cabinetId)
                .FirstOrDefault();
            if (cabinet == null)
            {
                throw new BadRequestException("Cabinet khong ton tai");
            }
            smartDeliveryContext.Cabinets.Remove(cabinet);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public CabinetEntity Get(Guid cabinetId)
        {
            Cabinet cabinet = smartDeliveryContext.Cabinets.Where(m => m.Id == cabinetId)
                .Include(m => m.Goods)
                .Include(m => m.Location)
                .FirstOrDefault();
            if (cabinet == null)
                throw new BadRequestException("Cabinet khong ton tai");
            return new CabinetEntity(cabinet, cabinet.Location, cabinet.Goods);
        }

        public List<CabinetEntity> Get()
        {
            IQueryable<Cabinet> cabinets = smartDeliveryContext.Cabinets
           .Include(m => m.Location)
           .Include(m => m.Goods);
            return cabinets.Select(u => new CabinetEntity(u, u.Location, u.Goods)).ToList();
        }

        public CabinetEntity Update(Guid cabinetId, CabinetEntity cabinetEntity)
        {
            Cabinet cabinet = smartDeliveryContext.Cabinets.Where(m => m.Id == cabinetId).FirstOrDefault();
            if (cabinet == null)
                throw new BadRequestException("Cabinet khong ton tai");
            cabinetEntity.ToModel(cabinet);
            smartDeliveryContext.Cabinets.Update(cabinet);
            smartDeliveryContext.SaveChanges();
            return cabinetEntity;
        }
    }
}
