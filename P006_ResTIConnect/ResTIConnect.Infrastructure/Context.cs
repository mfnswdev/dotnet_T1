using Microsoft.EntityFrameworkCore;

namespace ResTIConnect.Infrastructure.Context{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }

}