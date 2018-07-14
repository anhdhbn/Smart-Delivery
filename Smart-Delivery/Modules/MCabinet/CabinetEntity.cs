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
        public int? Status { get; set; }
        public Guid? GoodsId { get; set; }
        public Guid Code { get; set; }
        public Guid? LocationId { get; set; }
        public string Name { get; set; }

        public GoodsEntity Goods { get; set; }
        public RepositoryEntity Location { get; set; }

        public CabinetEntity(Cabinet cabinet, params object[] args)
        {
            this.Id = cabinet.Id;
            this.Status = cabinet.Status;
            this.GoodsId = cabinet.GoodsId;
            this.Code = cabinet.Code;
            this.LocationId = cabinet.LocationId;
            this.Name = cabinet.Name;
            foreach(var arg in args)
            {
                if (arg is Good) this.Goods = cabinet.Goods == null ? null : new GoodsEntity(arg as Good);
                if (arg is Repository) this.Location = cabinet.Location == null ? null : new RepositoryEntity(arg as Repository);
            }
        }

        public Cabinet ToModel(Cabinet cabinet = null)
        {
            if(cabinet == null)
            {
                cabinet = new Cabinet();
                cabinet.Id = new Guid();
            }
            cabinet.Status = this.Status;
            cabinet.Name = this.Name;
            cabinet.GoodsId = this.GoodsId;
            cabinet.Code = this.Code;
            cabinet.LocationId = this.LocationId;
            return cabinet;
        }
    }
}
