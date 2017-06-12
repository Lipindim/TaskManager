using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Context
{
    public class TaskManagerContext: DbContext
    {
        public TaskManagerContext(string connectionString): base(connectionString)
        {
            Database.SetInitializer(new DbInitializer());
        }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<StatusHistory> StatusHistories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
