using Microsoft.AspNetCore.Mvc;
using SmartDelivery.Models;
using SmartDelivery.MqttServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MMqtt
{
    [Route("api/Auth")]
    public class MqttController : CommonController
    {
        private IMqttService mqttService;
        private IMqttClientMain mqttClientMain;
        public MqttController(IMqttService mqttService, IMqttClientMain mqttClientMain)
        {
            this.mqttService = mqttService;
            this.mqttClientMain = mqttClientMain;
        }

        [Route("CustomerSend/{CodeCabinet}"), HttpGet]
        public bool CustomerSend([FromRoute]string CodeCabinet)
        {
            // locker1
            return mqttService.CustomerSend(CodeCabinet, UserEntity, mqttClientMain);
        }

        [Route("ShipperSend/{CodeCabinet}"), HttpGet]
        public bool AuthShipperSend(string CodeCabinet)
        {
            //locker1
            return mqttService.AuthShipperSend(CodeCabinet, mqttClientMain);
        }

        [Route("ShipperRecievie/{GoodsId}/{CodeCabinet}"), HttpGet]
        public bool AuthShipperRecievie(Guid GoodsId, string CodeCabinet)
        {
            //locker2
            return mqttService.AuthShipperRecievie(GoodsId, CodeCabinet, mqttClientMain);
        }


        [Route("CustomerRecievie/{CodeCabinet}"), HttpGet]
        public bool AuthCustomerRecievie(string CodeCabinet)
        {
            //locker2
            return mqttService.AuthCustomerRecievie(CodeCabinet, UserEntity, mqttClientMain);
        }

    }
}
