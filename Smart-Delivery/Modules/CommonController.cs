using Microsoft.AspNetCore.Mvc;
using SmartDelivery.Modules.MUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartDelivery.Modules
{
    public class CommonController : Controller
    {
        public UserEntity UserEntity => (User as MyPrincipal)?.UserEntity;
    }

    public class Helpper
    {
        public static bool CheckAuth(ClaimsPrincipal claimsPrincipal, Guid userId)
        {
            return (claimsPrincipal as MyPrincipal).UserEntity.Id.Equals(userId);
        }

        public static Guid GetId(ClaimsPrincipal claimsPrincipal)
        {
            return (claimsPrincipal as MyPrincipal).UserEntity.Id;
        }

        public static bool CheckAuth(ClaimsPrincipal claimsPrincipal)
        {
            return (claimsPrincipal as MyPrincipal).UserEntity.Role == (ROLES.USER | ROLES.ADMIN);
        }

        public static DateTime expires = DateTime.Now.AddDays(1);
    }
}
