using Microsoft.EntityFrameworkCore;
using Task = API_Parcial3.Controllers.DAL.Entities.Task;

namespace API_Parcial3.Controllers.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Task>().HasIndex(c => c.Id).IsUnique();
        }

        #region DbSet
        public DbSet<Task> Tasks { get; set; }

        #endregion
    }
}
