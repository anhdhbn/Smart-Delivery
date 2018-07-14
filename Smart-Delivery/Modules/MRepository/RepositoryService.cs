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
            Repositories repository = repositoryEntity.ToModel();
            smartDeliveryContext.Repositories.Add(repository);
            smartDeliveryContext.SaveChanges();
            return repositoryEntity;
        }

        public bool Delete(Guid repositoryId)
        {
            Repositories repository = smartDeliveryContext.Repositories.Where(m => m.Id == repositoryId)
               .Include(u => u.Cabinet)
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
            Repositories repository = smartDeliveryContext.Repositories.Where(m => m.Id == repositoryId)
               .Include(u => u.Cabinet)
               .FirstOrDefault();
            if (repository == null)
                throw new BadRequestException("Repository khong ton tai");
            return new RepositoryEntity(repository, repository.Cabinet);
        }

        public List<RepositoryEntity> Get()
        {

            IQueryable<Repositories> repositories = smartDeliveryContext.Repositories
                 .Include(u => u.Cabinet);
            return repositories.Select(u => new RepositoryEntity(u, u.Cabinet)).ToList();
        }

        public RepositoryEntity Update(Guid repositoryId, RepositoryEntity repositoryEntity)
        {

            Repositories repository = smartDeliveryContext.Repositories.Where(m => m.Id == repositoryId)
                .Include(u => u.Cabinet)
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
