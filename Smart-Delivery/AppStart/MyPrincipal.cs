using System.Security.Claims;
using SmartDelivery.Modules.MUser;

namespace SmartDelivery
{
    public class MyPrincipal : ClaimsPrincipal
    {
        public MyPrincipal(UserEntity UserEntity)
        {
            this.UserEntity = UserEntity;
        }

        public UserEntity UserEntity { get; set; }
      
    }
}
