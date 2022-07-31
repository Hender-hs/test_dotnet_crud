using Microsoft.EntityFrameworkCore;

namespace WebApplicationAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; } = false;
    }

    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();

        public void methodTEst()
        {

        }
    }
}
