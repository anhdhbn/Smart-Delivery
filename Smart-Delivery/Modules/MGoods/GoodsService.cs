using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MGoods
{
    public class GoodsService : CommonService, IGoodsService
    {
        public GoodsEntity Create(GoodsEntity goodsEntity)
        {
            Good good = goodsEntity.ToModel();
            smartDeliveryContext.Goods.Add(good);
            smartDeliveryContext.SaveChanges();
            return goodsEntity;
        }

        public bool Delete(Guid goodsId)
        {
            Good good = smartDeliveryContext.Goods.Where(m => m.Id == goodsId)
                .Include(u => u.Cabinets)
                .Include(u => u.Scales)
                .Include(u => u.ShipmentGoods)
                .FirstOrDefault();
            if (good == null)
            {
                throw new BadRequestException("Good khong ton tai");
            }
            smartDeliveryContext.Goods.Remove(good);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public GoodsEntity Get(Guid goodsId)
        {
            Good good = smartDeliveryContext.Goods.Where(m => m.Id == goodsId)
                 .Include(u => u.Cabinets)
                 .Include(u => u.Scales)
                 .Include(u => u.ShipmentGoods)
                 .FirstOrDefault();
            if (good == null)
                throw new BadRequestException("Good khong ton tai");
            return new GoodsEntity(good, good.Cabinets, good.Scales, good.ShipmentGoods);
        }

        public List<GoodsEntity> Get()
        {
            IQueryable<Good> goods = smartDeliveryContext.Goods
                 .Include(u => u.Cabinets)
                 .Include(u => u.ShipmentGoods)
                 .Include(u => u.Scales);
            return goods.Select(u => new GoodsEntity(u, u.Scales, u.Cabinets, u.ShipmentGoods)).ToList();
        }

        public GoodsEntity Update(Guid goodsId, GoodsEntity goodsEntity)
        {
            Good good = smartDeliveryContext.Goods.Where(m => m.Id == goodsId).FirstOrDefault();
            if (good == null)
                throw new BadRequestException("Good khong ton tai");
            goodsEntity.ToModel(good);
            smartDeliveryContext.Goods.Update(good);
            smartDeliveryContext.SaveChanges();
            return goodsEntity;
        }
    }
}
