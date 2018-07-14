using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MRepository
{
    [Route("api/Repository")]
    public class RepositoryController : CommonController
    {
        private IRepositoryService repositoryService;
        public RepositoryController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        [Route(""), HttpPost]
        public RepositoryEntity Create([FromBody]RepositoryEntity repositoryEntity)
        {
            return repositoryService.Create(repositoryEntity);
        }

        [Route(""), HttpGet]
        public List<RepositoryEntity> Get()
        {
            return repositoryService.Get();
        }
        [Route("{repositoryId}"), HttpGet]
        public RepositoryEntity Get(Guid repositoryId)
        {
            return repositoryService.Get(repositoryId);
        }

        [Route("{repositoryId}"), HttpPut]
        public RepositoryEntity Update(Guid repositoryId, [FromBody]RepositoryEntity repositoryEntity)
        {
            return repositoryService.Update(repositoryId, repositoryEntity);
        }

        [Route("{repositoryId}"), HttpGet]
        public RepositoryEntity Delete(Guid repositoryId)
        {
            return repositoryService.Get(repositoryId);
        }
    }
}
