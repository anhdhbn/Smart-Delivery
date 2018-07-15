using SmartDelivery.Models;
using SmartDelivery.Modules.MUser;
using SmartDelivery.MqttServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MMqtt
{
    public interface IMqttService : ITransientService
    {
        void UpdateWeightFromScale(MqttEntity mqttEntity);
        void ChangeHasGoodInCabinet(Cabinet cabinet);
        void UpdateOpenCabinet(string topic);

        bool CustomerSend(string CodeCabinet, UserEntity userEntity, IMqttClientMain mqttClientMain);
        bool AuthShipperSend(string CodeCabinet, IMqttClientMain mqttClientMain);
        bool AuthShipperRecievie(Guid GoodsId, string CodeCabinet, IMqttClientMain mqttClientMain);
        bool AuthCustomerRecievie(string CodeCabinet, UserEntity userEntity, IMqttClientMain mqttClientMain);
    }
}
