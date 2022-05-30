using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNEAKER_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNEAKER_SHOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSPsController : ControllerBase
    {
        private readonly SneakerShopDbContext _context;

        public CustomerSPsController(SneakerShopDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSP>>> GetCustomerSP()
        {
            return await _context.CustomerSP.ToListAsync();
        }



        [HttpPost]
        public async Task<ActionResult<CustomerSP>> Addfood([FromBody] addCustommerSp customerSP)
        {
            if (ModelState.IsValid)
            {
                var CustomerSP = new CustomerSP()
                {
                    CustomerSPName = customerSP.CustomerSPName,
                    CustomerSPEmail = customerSP.CustomerSPEmail,
                    CustomerSPPhone = customerSP.CustomerSPPhone,
                    customerSPDescriptions = customerSP.customerSPDescriptions,
                    BranchId = customerSP.BranchId,

                };

                _context.CustomerSP.Add(CustomerSP);
                await _context.SaveChangesAsync();
                return Ok(CustomerSP);
            }

            return BadRequest(ModelState.Values);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerSP(int id)
        {
            var customer = await _context.CustomerSP.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.CustomerSP.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.CustomerSP.Any(e => e.CustomerSPId == id);
        }

    }


}
