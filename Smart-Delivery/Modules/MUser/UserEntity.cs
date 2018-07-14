using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MUser
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ROLES Role { get; set; }

        public UserEntity(User user)
        {
            //if (user == null) return;
            this.Id = user.Id;
            this.Username = user.Username;
            this.Password = user.Password;
            this.Role = ROLES.USER;
            if (user.Admin != null) this.Role = ROLES.ADMIN | ROLES.USER;
        }

        public UserEntity()
        {

        }
    }
}
