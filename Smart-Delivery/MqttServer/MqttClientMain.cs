using SmartDelivery.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Serializer;

namespace SmartDelivery.MqttServer
{
    public interface IMqttClientMain
    {
        IMqttClient mqttClient { get; }
        List<string> listTopic { get; set; }
    }
    public class MqttClientMain : IMqttClientMain
    {
        public IMqttClient mqttClient { get; }
        public List<string> listTopic { get; set; }

        public MqttClientMain()
        {
            mqttClient = new MqttFactory().CreateMqttClient();
            var option = new MqttClientOptionsBuilder()
                        .WithCleanSession(true)
                        .WithClientId("Main client")
                        .WithCommunicationTimeout(TimeSpan.FromSeconds(5))
                        .WithKeepAlivePeriod(TimeSpan.FromSeconds(5))
                        .WithProtocolVersion(MqttProtocolVersion.V311)
                        .WithTcpServer("127.0.0.1", Convert.ToInt32(1883));
            mqttClient.ConnectAsync(option.Build());
            mqttClient.Connected += (sender, e) =>
            {
                string str = string.Format("Main Client connected");
                Console.WriteLine(str);
            };

            mqttClient.Disconnected += (sender, e) =>
            {
                string str = string.Format("Main Client disconnected");
                Console.WriteLine(str);
            };
            mqttClient.ApplicationMessageReceived += (sender, e) =>
            {
                string result = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                string str = string.Format("Main Client received message: {0}", result);
                Console.WriteLine(str);
            };
            listTopic = new List<string>();
        }
    }
}
