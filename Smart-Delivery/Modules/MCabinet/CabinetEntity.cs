using SmartDelivery.Models;
using SmartDelivery.Modules.MGoods;
using SmartDelivery.Modules.MRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MCabinet
{
    public class CabinetEntity
    {
        public Guid Id { get; set; }
        public bool? IsOpended { get; set; }
        public Guid? GoodsId { get; set; }
        public Guid Code { get; set; }
        public Guid? LocationId { get; set; }
        public string Name { get; set; }
        public bool? IsHadGoods { get; set; }

        public GoodsEntity Goods { get; set; }
        public RepositoryEntity Location { get; set; }
        public CabinetEntity() { }

        public CabinetEntity(Cabinet cabinet, params object[] args)
        {
            this.Id = cabinet.Id;
            this.IsHadGoods = cabinet.IsHadGoods;
            this.IsOpended = cabinet.IsOpended;
            this.GoodsId = cabinet.GoodsId;
            this.Code = cabinet.Code;
            this.LocationId = cabinet.LocationId;
            this.Name = cabinet.Name;
            foreach(var arg in args)
            {
                if (arg is Goods) this.Goods = cabinet.Goods == null ? null : new GoodsEntity(arg as Goods);
                if (arg is Repositories) this.Location = cabinet.Location == null ? null : new RepositoryEntity(arg as Repositories);
            }
        }

        public Cabinet ToModel(Cabinet cabinet = null)
        {
            if(cabinet == null)
            {
                cabinet = new Cabinet();
                cabinet.Id = Guid.NewGuid();
            }
            cabinet.IsOpended = this.IsOpended;
            cabinet.IsHadGoods = this.IsHadGoods;
            cabinet.Name = this.Name;
            cabinet.GoodsId = this.GoodsId;
            cabinet.Code = this.Code;
            cabinet.LocationId = this.LocationId;
            return cabinet;
        }
    }
}
