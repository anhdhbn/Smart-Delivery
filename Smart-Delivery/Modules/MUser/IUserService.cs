using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MUser
{
    public interface IUserService : ITransientService
    {
        UserEntity Get(Guid UserId);
        UserEntity Create(UserEntity UserEntity);
        string Login(UserEntity UserEntity);
    }
}
