using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNEAKER_SHOP_SAI_GON.Models
{
    public class SneakerShopSaiGonDbContext : DbContext
    {
        public SneakerShopSaiGonDbContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<New> News { get; set; }
    }
}
