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
            this.Id = scale.Id;
            this.GoodsId = scale.GoodsId;
            this.Weight = scale.Weight;
            foreach(var arg in args)
            {
                if (arg is Good) this.GoodsEntity = scale.Goods == null ? null : new GoodsEntity(arg as Good);
            }
        }

        public Scale ToModel(Scale scale = null)
        {
            if(scale == null)
            {
                scale = new Scale();
                scale.Id = new Guid();
            }
            scale.Id = this.Id;
            scale.GoodsId = this.GoodsId;
            scale.Weight = this.Weight;
            return scale;
        }
    }
}
