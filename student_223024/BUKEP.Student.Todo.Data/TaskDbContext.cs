using System.Data.Entity;

namespace BUKEP.Student.Todo.Data
{
    /// <summary>
    /// Класс доступа к базе данных через EntityFramework
    /// </summary>
    public class TaskDbContext : DbContext
    {
        public TaskDbContext() : base("Database")
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
