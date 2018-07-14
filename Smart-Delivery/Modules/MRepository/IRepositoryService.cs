using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MRepository
{
    public interface IRepositoryService : ITransientService
    {
        RepositoryEntity Create(RepositoryEntity repositoryEntity);
        RepositoryEntity Get(Guid repositoryId);
        List<RepositoryEntity> Get();
        RepositoryEntity Update(Guid repositoryId, RepositoryEntity repositoryEntity);
        bool Delete(Guid repositoryId);

    }
}
