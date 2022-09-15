using GraphQLBeginners.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBeginners.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
