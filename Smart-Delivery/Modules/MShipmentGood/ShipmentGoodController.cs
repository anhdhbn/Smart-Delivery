using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDelivery.Modules.MShipmentGood
{
    [Route("api/ShipmentGood")]
    public class ShipmentGoodController : Controller
    {
        private IShipmentGoodService shipmentGoodService;
        public ShipmentGoodController(IShipmentGoodService shipmentGoodService)
        {
            this.shipmentGoodService = shipmentGoodService;
        }

        [Route(""), HttpPost]
        public ShipmentGoodEntity Create([FromBody]ShipmentGoodEntity shipmentEntity)
        {
            return shipmentGoodService.Create(shipmentEntity);
        }

        [Route("{shipmentGoodId}"), HttpGet]
        public ShipmentGoodEntity Get(Guid shipmentGoodId)
        {
            return shipmentGoodService.Get(shipmentGoodId);
        }

        [Route(""), HttpGet]
        public List<ShipmentGoodEntity> Get()
        {
            return shipmentGoodService.Get();
        }

        [Route("{shipmentGoodId}"), HttpPut]
        public ShipmentGoodEntity Update(Guid shipmentGoodId, [FromBody]ShipmentGoodEntity shipmentEntity)
        {
            return shipmentGoodService.Update(shipmentGoodId, shipmentEntity);
        }

        [Route("{shipmentGoodId}"), HttpDelete]
        public bool Delete(Guid shipmentGoodId)
        {
            return shipmentGoodService.Delete(shipmentGoodId);
        }
    }
}
