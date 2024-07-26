using Microsoft.EntityFrameworkCore;
using Products.API.Model;

namespace Products.API.Infra
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}
