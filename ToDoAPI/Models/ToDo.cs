using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Models
{
    class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public Priority Priority { get; set; } = 0;
    }
    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
    enum Priority
    {
        Low,
        Normal,
        High
    }
}
