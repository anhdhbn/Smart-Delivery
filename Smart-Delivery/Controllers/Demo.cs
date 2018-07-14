using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using SmartDelivery.MqttServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDelivery.Controllers
{
    [Route("Demo")]
    public class Demo : Controller
    {
        private IMqttClientMain mqttClientMain;
        public Demo(IMqttClientMain mqttClientMain)
        {
            this.mqttClientMain = mqttClientMain;
        }
        [Route(""), HttpGet]
        public string Get()
        {
            string content = HttpContext.Request.Query["content"];
            foreach (var item in mqttClientMain.listTopic)
            {
                mqttClientMain.mqttClient.PublishAsync(new MqttApplicationMessage()
                {
                    Payload = Encoding.ASCII.GetBytes(content),
                    QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce,
                    Topic = item
                });
            }
            return "success";
        }
    }
}
