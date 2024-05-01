using Microsoft.EntityFrameworkCore;
using TestTaskTeledoc.Db.Models;

namespace TestTaskTeledoc.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
