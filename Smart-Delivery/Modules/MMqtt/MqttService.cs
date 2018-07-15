using SmartDelivery.Models;
using SmartDelivery.Modules.MUser;
using SmartDelivery.MqttServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MMqtt
{
    public class MqttService : CommonService, IMqttService
    {
        public void ChangeHasGoodInCabinet(Cabinet cabinet)
        {
            if (cabinet.IsOpended == false && cabinet.GoodsId != null)
                cabinet.IsOpended = true;
            else
                cabinet.IsHadGoods = false;
        }

        public bool CustomerSend(string CodeCabinet, UserEntity userEntity,IMqttClientMain mqttClientMain)
        {
            Cabinet cabinet = smartDeliveryContext.Cabinet.Where(x => x.Code.Equals(CodeCabinet)).FirstOrDefault();
            Goods goods = smartDeliveryContext.Goods.Where(x => x.IdSender == userEntity.Id).FirstOrDefault();
            if (goods != null)
            {
                if (cabinet.GoodsId == goods.Id)
                {
                    //cabinet.IsOpended = true;
                    smartDeliveryContext.SaveChanges();
                    mqttClientMain.PublishToTopicAsync("command/locker1", "0");
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public void UpdateOpenCabinet(string topic)
        {
            Cabinet cabinet = smartDeliveryContext.Cabinet.Where(x => topic.ToLower().Contains(x.Code)).FirstOrDefault();
            if (cabinet == null)
                throw new Exception();
            else
            {
                cabinet.IsOpended = false;
                cabinet.IsHadGoods = !cabinet.IsHadGoods;
            }

        }

        public void UpdateWeightFromScale(MqttEntity mqttEntity)
        {
            Goods goods = smartDeliveryContext.Goods.Where(x => x.Code == mqttEntity.ID).FirstOrDefault();
            if (goods == null)
                throw new Exception();
            goods.Weight = double.Parse(mqttEntity.weight);
            goods.Price = 5500;
            goods.Status = 2;

            Cabinet cabinet = smartDeliveryContext.Cabinet.Where(x => x.IsRecievieCabinet == false && x.IsOpended == true).FirstOrDefault();
            if (cabinet == null)
                throw new Exception();
            cabinet.GoodsId = goods.Id;
            smartDeliveryContext.SaveChanges();
        }

        public bool AuthShipperSend(string CodeCabinet, IMqttClientMain mqttClientMain)
        {
            Cabinet cabinet = smartDeliveryContext.Cabinet.Where(x => x.Code.Equals(CodeCabinet)).FirstOrDefault();
            cabinet.GoodsId = null;
            mqttClientMain.PublishToTopicAsync("command/locker1", "0");
            return true;
        }

        public bool AuthShipperRecievie(Guid GoodsId, string CodeCabinet, IMqttClientMain mqttClientMain)
        {
            Cabinet cabinet = smartDeliveryContext.Cabinet.Where(x => x.Code.Equals(CodeCabinet)).FirstOrDefault();
            Goods goods = smartDeliveryContext.Goods.Where(x => x.Id == GoodsId).FirstOrDefault();
            cabinet.GoodsId = goods.Id;
            goods.Status = 5;
            mqttClientMain.PublishToTopicAsync("command/locker2", "0");
            return true;
        }

        public bool AuthCustomerRecievie(string CodeCabinet, UserEntity userEntity, IMqttClientMain mqttClientMain)
        {
            Cabinet cabinet = smartDeliveryContext.Cabinet.Where(x => x.Code.Equals(CodeCabinet)).FirstOrDefault();
            Goods goods = smartDeliveryContext.Goods.Where(x => x.IdReceiver == userEntity.Id).FirstOrDefault();
            if (goods != null)
            {
                if (cabinet.GoodsId == goods.Id)
                {
                    //cabinet.IsOpended = true;
                    smartDeliveryContext.SaveChanges();
                    mqttClientMain.PublishToTopicAsync("command/locker2", "0");
                    return true;
                }
                else
                    return false;
            }
            return false;
        }
    }
}
