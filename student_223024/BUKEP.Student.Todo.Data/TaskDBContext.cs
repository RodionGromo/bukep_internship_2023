using System.Data.Entity;

namespace BUKEP.Student.Todo.Data
{
    class TaskDbContext : DbContext
    {
        public TaskDbContext() : base("Database")
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
