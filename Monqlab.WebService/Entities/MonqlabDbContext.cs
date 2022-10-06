using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace Monqlab.WebService.Entities
{
    public class MonqlabDbContext : DbContext
    {
        public virtual DbSet<SentMessage> SentMessages { get; set; }

        public MonqlabDbContext(DbContextOptions<MonqlabDbContext> opt) : base(opt)
        {
#if INITIAL
            Database.EnsureDeleted();
#endif
            var migrator = base.Database.GetService<IMigrator>();
            migrator.Migrate();
        }
    }
}
