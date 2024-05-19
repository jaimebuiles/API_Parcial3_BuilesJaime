﻿using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Entities.Task>().HasIndex(c => c.Id).IsUnique();
        }

        #region DbSet
        public DbSet<Entities.Task> Tasks { get; set; }

        #endregion
    }
}
