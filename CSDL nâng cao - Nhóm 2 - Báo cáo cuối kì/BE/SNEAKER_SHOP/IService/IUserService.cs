using Microsoft.AspNetCore.Mvc;
using SNEAKER_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNEAKER_SHOP.IService
{
    public interface IUserService
    {
        Task<ActionResult<User>> Signup(User user);
        UserLoginModel Login(UserLoginModel model);
        List<User> GetAllUsers();
    }
}
