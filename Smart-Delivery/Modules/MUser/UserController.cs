using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Collections.Specialized;
using System.Net.Http.Headers;

namespace SmartDelivery.Modules.MUser
{
    [Route("api/User")]
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("{UserId}"), HttpGet]
        public UserEntity Get(Guid UserId)
        {
            return userService.Get(UserId);
        }

        [Route(""), HttpGet]
        public UserEntity Get()
        {
            return userService.Get(Helpper.GetId(Request.HttpContext.User));
        }

        [Route(""), HttpPost]
        public UserEntity Create([FromBody]UserEntity UserEntity)
        {
            return userService.Create(UserEntity);
        }
        [Route("Login"), HttpPost]
        public string Login([FromBody] UserEntity UserEntity)
        {
            string token = userService.Login(UserEntity);
            var CookieOptions = new CookieOptions { Expires = Helpper.expires, Path = "/" };
            //Response.Cookies.Append("JWT", token, CookieOptions);
            return token;
        }
    }
}
