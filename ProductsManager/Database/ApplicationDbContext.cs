using Microsoft.EntityFrameworkCore;
using ProductsManager.Application.Model;

namespace ProductsManager.Database;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}
    public DbSet<Product> Products { get; set; }
}