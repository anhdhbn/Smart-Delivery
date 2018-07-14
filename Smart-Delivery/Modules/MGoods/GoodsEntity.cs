using SmartDelivery.Models;
using SmartDelivery.Modules.MCabinet;
using SmartDelivery.Modules.MScale;
using SmartDelivery.Modules.MShipmentGood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MGoods
{
    public class GoodsEntity
    {

        public Guid Id { get; set; }
        public Guid? IdReceiver { get; set; }
        public Guid? IdSender { get; set; }

        public ICollection<CabinetEntity> cabinetEntities { get; set; }
        public ICollection<ScaleEntity> scaleEntities { get; set; }
        public ICollection<ShipmentGoodEntity> shipmentGoodEntities { get; set; }

        public GoodsEntity(Goods good, params object[] args)
        {
            this.Id = good.Id;
            this.IdReceiver = good.IdReceiver;
            this.IdSender = good.IdSender;
            foreach(var arg in args)
            {
                if (arg is ICollection<Cabinet>)
                    this.cabinetEntities = (arg as ICollection<Cabinet>).Select(u => new CabinetEntity(u)).ToList();
                if (arg is ICollection<Scale>)
                    this.scaleEntities = (arg as ICollection<Scale>).Select(u => new ScaleEntity(u)).ToList();
                if (arg is ICollection<ShipmentGoods>)
                    this.shipmentGoodEntities = (arg as ICollection<ShipmentGoods>).Select(u => new ShipmentGoodEntity(u)).ToList();
            }
        }
        public GoodsEntity()
        {

        }
        public Goods ToModel(Goods good = null)
        {
            if(good == null)
            {
                good = new Goods();
                good.Id = new Guid();
            }
            good.IdReceiver = this.IdReceiver;
            good.IdSender = this.IdSender;
            return good;
        }
    }
}
