using System.Data.Entity;

namespace BUKEP.Student.Todo.Data
{
	class TaskDBContext : DbContext
	{
		public TaskDBContext() : base("Database")
		{
		}

		public DbSet<Task> Tasks { get; set;}
	}
}
