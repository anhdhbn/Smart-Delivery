using SmartDelivery.Models;
using SmartDelivery.Modules.MGoods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MScale
{
    public class ScaleEntity
    {
        public Guid Id { get; set; }
        public Guid GoodsId { get; set; }
        public double Weight { get; set; }

        public GoodsEntity GoodsEntity { get; set; }

        public ScaleEntity(Scale scale, params object[] args)
        {
            //if (scale == null) return;
            this.Id = scale.Id;
            this.GoodsId = scale.GoodsId;
            this.Weight = scale.Weight;
            foreach(var arg in args)
            {
                if (arg is Goods) this.GoodsEntity = scale.Goods == null ? null : new GoodsEntity(arg as Goods);
            }
        }

        public ScaleEntity()
        {

        }

        public Scale ToModel(Scale scale = null)
        {
            if(scale == null)
            {
                scale = new Scale();
                scale.Id = Guid.NewGuid();
            }
            scale.Id = Guid.NewGuid();
            scale.GoodsId = this.GoodsId;
            scale.Weight = this.Weight;
            return scale;
        }
    }
}
