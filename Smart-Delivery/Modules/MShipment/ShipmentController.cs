using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDelivery.Modules.MShipment
{
    [Route("api/Shipment")]
    public class ShipperController : Controller
    {
        private IShipmentService shipmentService;
        public ShipperController(IShipmentService shipmentService)
        {
            this.shipmentService = shipmentService;
        }

        [Route(""), HttpPost]
        public ShipmentEntity Create([FromBody]ShipmentEntity shipmentEntity)
        {
            return shipmentService.Create(shipmentEntity);
        }

        [Route("{shipmentId}"), HttpGet]
        public ShipmentEntity Get(Guid shipmentId)
        {
            return shipmentService.Get(shipmentId);
        }

        [Route(""), HttpGet]
        public List<ShipmentEntity> Get()
        {
            return shipmentService.Get();
        }

        [Route("{shipmentId}"), HttpPut]
        public ShipmentEntity Update(Guid shipmentId, [FromBody]ShipmentEntity shipmentEntity)
        {
            return shipmentService.Update(shipmentId, shipmentEntity);
        }

        [Route("{shipmentId}"), HttpDelete]
        public bool Delete(Guid shipmentId)
        {
            return shipmentService.Delete(shipmentId);
        }
    }
}
