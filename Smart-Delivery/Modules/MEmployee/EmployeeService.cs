using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmartDelivery.Modules.MEmployee
{
    public class EmployeeService : CommonService, IEmployeeService
    {
        public EmployeeEntity Create(EmployeeEntity employeeEntity)
        {
            Employee employee = employeeEntity.ToModel();
            User User = new User();
            User.Id = employee.Id;
            User.Username = employeeEntity.Username;
            User.Password = "12345abcd";
            smartDeliveryContext.User.Add(User);
            smartDeliveryContext.Employee.Add(employee);
            smartDeliveryContext.SaveChanges();
            return new EmployeeEntity(employee);
        }

        public bool Delete(Guid employeeId)
        {
            Employee employee = smartDeliveryContext.Employee.Where(m => m.Id == employeeId)
                .Include(u => u.IdNavigation)
                .FirstOrDefault();
            User user = smartDeliveryContext.User.Where(m => m.Id == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new BadRequestException("Employee khong ton tai");
            }
            smartDeliveryContext.User.Remove(user);
            smartDeliveryContext.Employee.Remove(employee);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public EmployeeEntity Get(Guid employeeId)
        {
            Employee employee = smartDeliveryContext.Employee.Where(m => m.Id == employeeId)
                   .Include(m => m.IdNavigation) 
                   .FirstOrDefault();
            if (employee == null)
                throw new BadRequestException("Employee khong ton tai");
            return new EmployeeEntity(employee, employee.IdNavigation);
        }

        public List<EmployeeEntity> Get()
        {

            IQueryable<Employee> employees = smartDeliveryContext.Employee
           .Include(m => m.IdNavigation);
            return employees.Select(u => new EmployeeEntity(u, u.IdNavigation)).ToList();
        }

        public EmployeeEntity Update(Guid employeeId, EmployeeEntity employeeEntity)
        {
            Employee employee = smartDeliveryContext.Employee.Where(m => m.Id == employeeId).FirstOrDefault();
            if (employee == null)
                throw new BadRequestException("Employee khong ton tai");
            employeeEntity.ToModel(employee);
            smartDeliveryContext.Employee.Update(employee);
            smartDeliveryContext.SaveChanges();
            return employeeEntity;
        }
    }
}
