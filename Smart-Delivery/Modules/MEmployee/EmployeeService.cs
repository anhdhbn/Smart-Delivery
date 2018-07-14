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
            smartDeliveryContext.Users.Add(User);
            smartDeliveryContext.Employees.Add(employee);
            smartDeliveryContext.SaveChanges();
            return employeeEntity;
        }

        public bool Delete(Guid employeeId)
        {
            Employee employee = smartDeliveryContext.Employees.Where(m => m.Id == employeeId)
                .Include(u => u.IdNavigation)
                .FirstOrDefault();
            User user = smartDeliveryContext.Users.Where(m => m.Id == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new BadRequestException("Employee khong ton tai");
            }
            smartDeliveryContext.Users.Remove(user);
            smartDeliveryContext.Employees.Remove(employee);
            smartDeliveryContext.SaveChanges();
            return true;
        }

        public EmployeeEntity Get(Guid employeeId)
        {
            Employee employee = smartDeliveryContext.Employees.Where(m => m.Id == employeeId)
                   .Include(m => m.IdNavigation) 
                   .FirstOrDefault();
            if (employee == null)
                throw new BadRequestException("Employee khong ton tai");
            return new EmployeeEntity(employee, employee.IdNavigation);
        }

        public List<EmployeeEntity> Get()
        {

            IQueryable<Employee> employees = smartDeliveryContext.Employees
           .Include(m => m.IdNavigation);
            return employees.Select(u => new EmployeeEntity(u, u.IdNavigation)).ToList();
        }

        public EmployeeEntity Update(Guid employeeId, EmployeeEntity employeeEntity)
        {
            Employee employee = smartDeliveryContext.Employees.Where(m => m.Id == employeeId).FirstOrDefault();
            if (employee == null)
                throw new BadRequestException("Employee khong ton tai");
            employeeEntity.ToModel(employee);
            smartDeliveryContext.Employees.Update(employee);
            smartDeliveryContext.SaveChanges();
            return employeeEntity;
        }
    }
}
