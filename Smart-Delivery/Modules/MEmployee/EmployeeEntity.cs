using SmartDelivery.Models;
using SmartDelivery.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MEmployee
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Display { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public long? Cx { get; set; }

        public UserEntity IdNavigation { get; set; }

        public EmployeeEntity(Employee employee, params object[] args)
        {
            this.Cx = employee.Cx;
            this.Id = employee.Id;
            this.Display = employee.Display;
            this.Username = employee.Username;
            this.Password = employee.Password;
            this.Phone = employee.Phone;
            this.Picture = employee.Picture;
            foreach(var arg in args)
            {
                if (arg is UserEntity) this.IdNavigation = employee.IdNavigation == null ? null : new UserEntity(arg as User);
            }
        }
        public Employee ToModel(Employee employee = null)
        {
            if(employee == null)
            {
                employee = new Employee();
                employee.Id = new Guid();
            }
            employee.Username = this.Username;
            employee.Password = this.Password;
            employee.Phone = this.Phone;
            employee.Picture = this.Picture;
            employee.Display = this.Display;
            employee.Cx = this.Cx;
            return employee;
        }
    }
}
