using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNEAKER_SHOP_DA_NANG.Models
{
    public class SneakerShopDaNangDbContext : DbContext
    {
        public SneakerShopDaNangDbContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
    }
}
