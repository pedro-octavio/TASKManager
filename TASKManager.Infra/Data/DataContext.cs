using Microsoft.EntityFrameworkCore;
using TASKManager.Domain.Entities;

namespace TASKManager.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}
