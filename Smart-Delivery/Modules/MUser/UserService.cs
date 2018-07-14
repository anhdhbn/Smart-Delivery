using Microsoft.EntityFrameworkCore;
using SmartDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDelivery.Modules.MUser
{
    public class UserService : CommonService, IUserService
    {
        private IJWTHandler JWTHandler;
         
        public UserService(IJWTHandler JWTHandler) : base()
        {
            this.JWTHandler = JWTHandler;
        }

        public UserEntity Get(Guid UserId)
        {
            User User = smartDeliveryContext.User
                .Include(x => x.Admin)
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.Shipper)
                .Where(u => u.Id == UserId).FirstOrDefault();
            if (User == null)
                throw new BadRequestException("User không tồn tại");
            return new UserEntity(User);
        }

        public UserEntity Create(UserEntity UserEntity)
        {
            if (string.IsNullOrEmpty(UserEntity.Username))
                throw new BadRequestException("Bạn chưa điền Username");
            if (string.IsNullOrEmpty(UserEntity.Password))
                throw new BadRequestException("Bạn chưa điền Password");
            User User = smartDeliveryContext.User
                .Include(x=>x.Admin)
                .Include(x=>x.Customer)
                .Include(x=>x.Employee)
                .Include(x=>x.Shipper)
                .Where(u => u.Username.ToLower().Equals(UserEntity.Username.ToLower())).FirstOrDefault();
            if (User == null)
            {
                User = new User();
                User.Id = Guid.NewGuid();
                User.Username = UserEntity.Username;

                smartDeliveryContext.User.Add(User);
            }
            User.Password = (UserEntity.Password);
            smartDeliveryContext.SaveChanges();
            UserEntity.Id = User.Id;
            UserEntity.Password = User.Password;
            return UserEntity;

        }

        public string Login(UserEntity UserEntity)
        {
            if (string.IsNullOrEmpty(UserEntity.Username))
                throw new BadRequestException("Bạn chưa điền Username");
            if (string.IsNullOrEmpty(UserEntity.Password))
                throw new BadRequestException("Bạn chưa điền Password");

            User User = smartDeliveryContext.User
                .Include(x => x.Admin)
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.Shipper)
               .Where(u => u.Username.ToLower().Equals(UserEntity.Username.ToLower())).FirstOrDefault();

            if (User == null)
                throw new BadRequestException("User không tồn tại.");
            string hashPassword = (UserEntity.Password);
            if (!User.Password.Equals(UserEntity.Password))
                throw new BadRequestException("Bạn nhập sai password.");
            UserEntity = new UserEntity(User);
            UserEntity.Role = ROLES.USER;
            return JWTHandler.CreateToken(UserEntity, Helpper.expires);
        }

        public List<UserEntity> Get()
        {
            IQueryable<User> users = smartDeliveryContext.User;
            return users.Select(u => new UserEntity(u)).ToList();
        }

        public bool Delete(Guid UserId)
        {
            User user = smartDeliveryContext.User.Where(u => u.Id == UserId).FirstOrDefault();
            if (user == null)
                throw new BadRequestException("User khong ton tai");
            smartDeliveryContext.User.Remove(user);
            smartDeliveryContext.SaveChanges();
            return true;
        }
    }
}
