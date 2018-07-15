using Microsoft.AspNetCore.Mvc;
using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MOther
{
    [Route("api/GetNews")]
    public class OtherController : CommonController
    {
        private SmartDeliveryContext SmartDeliveryContext;
        public OtherController()
        {
            SmartDeliveryContext = new SmartDeliveryContext();
        }
        [Route("/Cabinet/{IdGoods}"), HttpGet]
        public string Get(Guid IdGoods)
        {
            Cabinet cabinet = SmartDeliveryContext.Cabinet.Where(x => x.GoodsId == IdGoods).FirstOrDefault();
            return cabinet.Name;
        }
    }
}
