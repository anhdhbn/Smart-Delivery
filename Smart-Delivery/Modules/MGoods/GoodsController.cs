﻿using Microsoft.AspNetCore.Mvc;
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

        [Route("{goodsId}"), HttpGet]
        public GoodsEntity Delete(Guid goodsId)
        {
            return goodsService.Get(goodsId);
        }
    }
}