using SmartDelivery.Models;
using SmartDelivery.Modules.MCabinet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MRepository
{
    public class RepositoryEntity
    {
        public Guid Id { get; set; }
        public string Location { get; set; }

        public ICollection<CabinetEntity> Cabinets { get; set; }

        public RepositoryEntity(Repository repository, params object[] args)
        {
            this.Id = repository.Id;
            this.Location = repository.Location;
            foreach(var arg in args)
            {
                if (arg is ICollection<Cabinet>)
                    this.Cabinets = (arg as ICollection<Cabinet>).Select(u => new CabinetEntity(u)).ToList();
            }
        }

        public Repository ToModel(Repository repository = null)
        {
            if(repository == null)
            {
                repository = new Repository();
                repository.Id = new Guid();
            }
            repository.Location = this.Location;
            return repository;
        }
    }
}
