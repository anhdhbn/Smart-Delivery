using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MGoods
{
    [Route("api/Good")]
    public class GoodsController : CommonController
    {
        private IGoodsService goodsService;
        public GoodsController(IGoodsService goodsService)
        {
            this.goodsService = goodsService;
        }

        [Route(""), HttpPost]
        public GoodsEntity Create([FromBody]GoodsEntity goodsEntity)
        {
            return goodsService.Create(goodsEntity);
        }

        [Route(""), HttpGet]
        public List<GoodsEntity> Get()
        {
            return goodsService.Get();
        }
        [Route("recievier/{recievierId}"), HttpGet]
        public List<GoodsEntity> GetByRecieverId(Guid recievierId)
        {
            return goodsService.GetByReceiverId(recievierId);
        }
        [Route("sender/{senderId}"), HttpGet]
        public List<GoodsEntity> GetBySenderId(Guid senderId)
        {
            return goodsService.GetBySenderId(senderId);
        }
        [Route("{goodsId}"), HttpGet]
        public GoodsEntity Get(Guid goodsId)
        {
            return goodsService.Get(goodsId);
        }

        [Route("{goodsId}"), HttpPut]
        public GoodsEntity Update(Guid goodsId, [FromBody]GoodsEntity goodsEntity)
        {
            return goodsService.Update(goodsId, goodsEntity);
        }

        [Route("{goodsId}"), HttpDelete]
        public bool Delete(Guid goodsId)
        {
            return goodsService.Delete(goodsId);
        }
    }
}
