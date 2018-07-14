using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.MqttServer
{
    public class MqttConfig 
    {
        private readonly IMqttServer mqttServer;
        private readonly IMqttClientMain mqttClientMain;
        public MqttConfig(IMqttServer mqttServer, IMqttClientMain mqttClientMain)
        {
            this.mqttServer = mqttServer;
            this.mqttClientMain = mqttClientMain;
        }

        public void Config()
        {
            Config_ApplicationMessageReceived();
            Config_ClientConnected();
            Config_ClientDisconnected();
            Config_ClientSubscribedTopic();
            Config_ClientUnsubscribedTopic();
            Config_Started();
            Config_Stopped();
        }

        private void Config_ApplicationMessageReceived()
        {
            mqttServer.ApplicationMessageReceived += (sender, e) =>
            {
                string result = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                string str = string.Format("Event-ApplicationMessageReceived \n\tFrom: {0} \n\t\tWith topic: {1} \n\t\t\tData sent: {2} \n\t\t\t\tQuality Of Service Level: {3} \n\t\t\t\t\tRetain: ",
                e.ClientId,
                e.ApplicationMessage.Topic,
                result,
                e.ApplicationMessage.QualityOfServiceLevel,
                e.ApplicationMessage.Retain);
                Console.WriteLine(str);
            };
        }

        private void Config_ClientConnected()
        {
            mqttServer.ClientConnected += (sender, e) =>
            {
                string str = string.Format("Event-ClientConnected: {0}", e.ClientId);
                Console.WriteLine(str);
            };
        }
        
        private void Config_ClientDisconnected()
        {
            mqttServer.ClientDisconnected += (sender, e) =>
            {
                string str = string.Format("Event-ClientDisconnected: {0} ", e.ClientId);
                Console.WriteLine(str);
            };
        }

        private void Config_ClientSubscribedTopic()
        {
            mqttServer.ClientSubscribedTopic += (sender, e) =>
            {
                
                string str = string.Format("Event-ClientSubscribedTopic: \n\tClient: {0}\n\t\tTopic: {1} \n\t\t\tQuality Of Service Level: {2}",
                e.ClientId, e.TopicFilter.Topic, e.TopicFilter.QualityOfServiceLevel);
                Console.WriteLine(str);
                if (e.ClientId == "Main client")
                    return;
                mqttClientMain.listTopic.Add(e.TopicFilter.Topic);
                mqttClientMain.mqttClient.SubscribeAsync(new List<TopicFilter>() { new TopicFilter(e.TopicFilter.Topic, e.TopicFilter.QualityOfServiceLevel) });
            };
        }

        private void Config_ClientUnsubscribedTopic()
        {
            mqttServer.ClientUnsubscribedTopic += (sender, e) =>
            {
                string str = string.Format("Event-ClientUnsubscribedTopic: \n\tClient: {0}\n\t\tTopic: {1}",
                e.ClientId, e.TopicFilter);
                Console.WriteLine(str);
            };
        }

        private void Config_Started()
        {
            mqttServer.Started += (sender, e) =>
            {
                string str = string.Format("MQTT server has started...");
                Console.WriteLine(str);
            };
        }

        private void Config_Stopped()
        {
            mqttServer.Stopped += (sender, e) =>
            {
                string str = string.Format("MQTT server has stopped...");
                Console.WriteLine(str);
            };
        }
    }
}
