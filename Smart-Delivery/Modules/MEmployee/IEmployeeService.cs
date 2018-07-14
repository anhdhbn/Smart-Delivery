using SmartDelivery.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MEmployee
{
    public interface IEmployeeService : ITransientService
    {
        EmployeeEntity Create(EmployeeEntity employeeEntity);
        EmployeeEntity Get( Guid employeeId);
        List<EmployeeEntity> Get();
        EmployeeEntity Update(Guid employeeId, EmployeeEntity employeeEntity);
        bool Delete(Guid employeeId);

    }
}
