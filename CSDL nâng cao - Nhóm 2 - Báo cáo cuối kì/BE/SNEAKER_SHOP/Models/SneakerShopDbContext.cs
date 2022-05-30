using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SNEAKER_SHOP.Footer;
using SNEAKER_SHOP.News;
using SNEAKER_SHOP.Service;
using SNEAKER_SHOP.Order;
using SNEAKER_SHOP.Chart;

namespace SNEAKER_SHOP.Models
{
    public class SneakerShopDbContext : DbContext
    {
        public SneakerShopDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HotProduct> HotProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ChartBill> Charts { get; set; }
        public DbSet<MoneyChart> MoneyCharts { get; set; }
        public DbSet<UserChart> UserCharts { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<CustomerSP> CustomerSP { get; set; }
    }
}
