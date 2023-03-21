using Microsoft.EntityFrameworkCore;
using TodoList.Domain;

namespace TodoList.Persistence.Contextos
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) { }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .ToTable("Tag")
                .Property(tag => tag.Title);
        }
    }
}