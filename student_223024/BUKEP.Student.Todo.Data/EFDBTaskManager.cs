
namespace BUKEP.Student.Todo.Data
{
	public class EFDBTaskManager : ITaskManager
	{
		public void AddTask(string name, string description)
		{
			using TaskDBContext db = new();
			db.Tasks.Add(new() { Name = name, Description = description });
			db.SaveChanges();
		}

		public void EditTask(int id, string? name, string? description)
		{
			using TaskDBContext db = new();
			var taskToEdit = db.Tasks.Where((task) => task.Id == id).First();
			if (!string.IsNullOrWhiteSpace(name))
			{
				taskToEdit.Name = name;
			}
			if (!string.IsNullOrWhiteSpace(description))
			{
				taskToEdit.Description = description;
			}
			db.SaveChanges();
		}

		public Task? GetTaskById(int id)
		{
			using TaskDBContext db = new();
			return db.Tasks.Where((task) => task.Id == id).First();
		}

		public IEnumerable<Task> GetTasks()
		{
			using TaskDBContext db = new();
			foreach(var task in db.Tasks)
			{
				yield return task;
			}
		}

		public void RemoveTask(Task task)
		{
			using TaskDBContext db = new();
			Task? taskToDelete = GetTaskById(task.Id);
			if(taskToDelete != null)
			{
				db.Tasks.Attach(taskToDelete);
				db.Tasks.Remove(taskToDelete);
				db.SaveChanges();
			}
		}
	}
}
