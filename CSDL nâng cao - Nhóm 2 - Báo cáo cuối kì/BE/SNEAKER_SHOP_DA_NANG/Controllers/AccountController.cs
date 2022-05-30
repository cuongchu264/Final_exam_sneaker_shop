using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SNEAKER_SHOP_DA_NANG.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SNEAKER_SHOP_DA_NANG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SneakerShopDaNangDbContext _context;

        public AccountController(SneakerShopDaNangDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //Get Info via UserName
        [HttpGet("viaUserName")]
        public async Task<ActionResult<IEnumerable<User>>> GetInfoViaUserName([FromQuery] string UserName)
        {
            var data = from p in _context.Users
                       where (p.UserName == UserName)
                       select (p);
            return await data.ToListAsync();
        }

        //Get User via MonthCreate
        [HttpGet("viaMonthCreate")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserViaMonthCreate([FromQuery] string Month)
        {
            int tmp;
            tmp = int.Parse(Month);
            var data = from p in _context.Users
                       where p.DayCreated.Value.Month == tmp
                       select (p);
            return await data.ToListAsync();
        }



        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}

