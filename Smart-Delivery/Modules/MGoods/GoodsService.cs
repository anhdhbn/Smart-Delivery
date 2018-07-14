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
            Goods good = goodsEntity.ToModel();
            smartDeliveryContext.Goods.Add(good);
            smartDeliveryContext.SaveChanges();
            return goodsEntity;
        }

        public bool Delete(Guid goodsId)
        {
            Goods good = smartDeliveryContext.Goods.Where(m => m.Id == goodsId)
                .Include(u => u.Cabinet)
                .Include(u => u.Scale)
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
            Goods good = smartDeliveryContext.Goods.Where(m => m.Id == goodsId)
                 .Include(u => u.Cabinet)
                 .Include(u => u.Scale)
                 .Include(u => u.ShipmentGoods)
                 .FirstOrDefault();
            if (good == null)
                throw new BadRequestException("Good khong ton tai");
            return new GoodsEntity(good, good.Cabinet, good.Scale, good.ShipmentGoods);
        }

        public List<GoodsEntity> Get()
        {
            IQueryable<Goods> goods = smartDeliveryContext.Goods
                 .Include(u => u.Cabinet)
                 .Include(u => u.ShipmentGoods)
                 .Include(u => u.Scale);
            return goods.Select(u => new GoodsEntity(u, u.Scale, u.Cabinet, u.ShipmentGoods)).ToList();
        }

        public GoodsEntity Update(Guid goodsId, GoodsEntity goodsEntity)
        {
            Goods good = smartDeliveryContext.Goods.Where(m => m.Id == goodsId).FirstOrDefault();
            if (good == null)
                throw new BadRequestException("Good khong ton tai");
            goodsEntity.ToModel(good);
            smartDeliveryContext.Goods.Update(good);
            smartDeliveryContext.SaveChanges();
            return goodsEntity;
        }

    }
}
