using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MScale
{
    [Route("api/Scale")]
    public class ScaleController : CommonController
    {
        private IScaleService scaleService;
        public ScaleController(IScaleService scaleService)
        {
            this.scaleService = scaleService;
        }

        [Route(""), HttpPost]
        public ScaleEntity Create([FromBody]ScaleEntity scaleEntity)
        {
            return scaleService.Create(scaleEntity);
        }

        [Route("{scaleId}"), HttpGet]
        public ScaleEntity Get(Guid scaleId)
        {
            return scaleService.Get(scaleId);
        }

        [Route(""), HttpGet]
        public List<ScaleEntity> Get()
        {
            return scaleService.Get();
        }

        [Route("{scaleId}"), HttpPut]
        public ScaleEntity Update(Guid scaleId, [FromBody]ScaleEntity scaleEntity)
        {
            return scaleService.Update(scaleId, scaleEntity);
        }

        [Route("{scaleId}"), HttpDelete]
        public bool Delete(Guid scaleId)
        {
            return scaleService.Delete(scaleId);
        }
    }
}
