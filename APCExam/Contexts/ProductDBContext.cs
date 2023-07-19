using Microsoft.EntityFrameworkCore;

namespace APCExam.Contexts;

public class ProductDBContext: DbContext
{
    public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
}