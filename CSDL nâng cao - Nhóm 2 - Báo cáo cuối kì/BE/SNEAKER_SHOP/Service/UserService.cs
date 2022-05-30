using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SNEAKER_SHOP.Common;
using SNEAKER_SHOP.IService;
using SNEAKER_SHOP.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SNEAKER_SHOP.Service
{
    public class UserService : IUserService
    {
        private readonly SneakerShopDbContext _context;
        public UserService(SneakerShopDbContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public UserLoginModel Login(UserLoginModel model)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);
            if (user != null)
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
                if (isValidPassword)
                {
                    return model;
                }
            }
            return null;
        }

        public async Task<ActionResult<User>> Signup(User user)
        {
              user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
              _context.Users.Add(user);
              await _context.SaveChangesAsync();
              return user;
        }
    }
}
