using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Core.Entities;
using ToDoList.Infra.Database.Configurations;

namespace ToDoList.Infra.Database
{
    public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DG1LLR4\SQLEXPRESS;Database=TodoList;Integrated Security=true;TrustServerCertificate=true;");
        }

        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ToDoItem> toDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new ToDoItemConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
