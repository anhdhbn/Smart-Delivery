using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MCabinet
{
    [Route("api/Cabinet")]
    public class CabinetController : CommonController
    {
        private CabinetService cabinetService;
        public CabinetController(CabinetService cabinetService)
        {
            this.cabinetService = cabinetService;
        }

        [Route(""), HttpPost]
        public CabinetEntity Create([FromBody]CabinetEntity cabinetEntity)
        {
            return cabinetService.Create(cabinetEntity);
        }
        [Route(""), HttpGet]
        public List<CabinetEntity> Get()
        {
            return cabinetService.Get();
        }

        [Route("{cabinetId}"), HttpGet]
        public CabinetEntity Get(Guid cabinetId)
        {
            return cabinetService.Get(cabinetId);
        }

        [Route("{cabinetId}"), HttpPut]
        public CabinetEntity Update(Guid cabinetId, [FromBody]CabinetEntity cabinetEntity)
        {
            return cabinetService.Update(cabinetId, cabinetEntity);
        }

        [Route("{cabinetId}"), HttpDelete]
        public bool Delete(Guid cabinetId)
        {
            return cabinetService.Delete(cabinetId);
        }
    }
}
