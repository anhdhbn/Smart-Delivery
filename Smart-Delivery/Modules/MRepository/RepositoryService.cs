using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MRepository
{
    public class RepositoryService : CommonService, IRepositoryService
    {
        public RepositoryEntity Create(RepositoryEntity repositoryEntity)
        {
            Repository repository = repositoryEntity.ToModel();
            smartDeliveryContext.Repositories.Add(repository);
            smartDeliveryContext.SaveChanges();
            return repositoryEntity;
        }

        public bool Delete(Guid repositoryId)
        {
            Repository repository = smartDeliveryContext.Repositories.Where(m => m.Id == repositoryId)
               .Include(u => u.Cabinets)
               .FirstOrDefault();
            if (repository == null)
            {
                throw new BadRequestException("Repository khong ton tai");
            }
            smartDeliveryContext.Repositories.Remove(repository);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public RepositoryEntity Get(Guid repositoryId)
        {
            Repository repository = smartDeliveryContext.Repositories.Where(m => m.Id == repositoryId)
               .Include(u => u.Cabinets)
               .FirstOrDefault();
            if (repository == null)
                throw new BadRequestException("Repository khong ton tai");
            return new RepositoryEntity(repository, repository.Cabinets);
        }

        public List<RepositoryEntity> Get()
        {

            IQueryable<Repository> repositories = smartDeliveryContext.Repositories
                 .Include(u => u.Cabinets);
            return repositories.Select(u => new RepositoryEntity(u, u.Cabinets)).ToList();
        }

        public RepositoryEntity Update(Guid repositoryId, RepositoryEntity repositoryEntity)
        {

            Repository repository = smartDeliveryContext.Repositories.Where(m => m.Id == repositoryId)
                .Include(u => u.Cabinets)
                .FirstOrDefault();
            if (repository == null)
                throw new BadRequestException("Repository khong ton tai");
            repositoryEntity.ToModel(repository);
            smartDeliveryContext.Repositories.Update(repository);
            smartDeliveryContext.SaveChanges();
            return repositoryEntity;
        }
    }
}
