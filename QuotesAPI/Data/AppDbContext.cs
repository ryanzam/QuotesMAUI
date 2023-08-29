using Microsoft.EntityFrameworkCore;
using QuotesAPI.Models;

namespace QuotesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
