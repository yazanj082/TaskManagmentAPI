using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Persistence.Data
{
    public class TaskDBContext:DbContext
    {

        public DbSet<UserData> User { get; set; }
        public DbSet<TaskData> Task { get; set; }
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskData>().HasOne(u => u.Owner).WithMany(t => t.Tasks).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<TaskData>().HasIndex(x =>new { x.Title ,x.UserId}).IsUnique();
            modelBuilder.Entity<UserData>().HasIndex(x => x.UserName).IsUnique();
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
