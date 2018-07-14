
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MGoods
{
    public interface IGoodsService : ITransientService
    {
        GoodsEntity Create(GoodsEntity goodsEntity);
        GoodsEntity Get(Guid goodsId);
        List<GoodsEntity> Get();
        GoodsEntity Update(Guid goodsId, GoodsEntity olderEntity);
        bool Delete(Guid goodsId);

    }
}
