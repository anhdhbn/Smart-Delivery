using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using SmartDelivery.MqttServer;

namespace Smart_Delivery.Controllers
{
    public class TestController : Controller
    {
        private IMqttClientMain mqttClientMain;
        public TestController(IMqttClientMain mqttClientMain)
        {
            this.mqttClientMain = mqttClientMain;
        }
        public void Index()
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
            
        }
    }
}