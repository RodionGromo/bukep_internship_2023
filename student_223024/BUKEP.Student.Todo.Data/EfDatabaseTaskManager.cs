
namespace BUKEP.Student.Todo.Data
{
    /// <summary>
    /// Класс для доступа к списку задач используя EntityFramework вместе с базами данных
    /// </summary>
    public class EfDatabaseTaskManager : ITaskManager
    {
        /// <inheritdoc/>
        public void AddTask(string name, string description)
        {
            using TaskDbContext db = new();
            db.Tasks.Add(new() { Name = name, Description = description });
            db.SaveChanges();
        }

        /// <inheritdoc/>
        public void EditTask(int id, string? name, string? description)
        {
            using TaskDbContext db = new();
            var taskToEdit = db.Tasks.Where((task) => task.Id == id).First();
            if (!string.IsNullOrWhiteSpace(name))
            {
                // мне тут visual studio кидает предупреждение о nullable, а на описание нет, почему?
                taskToEdit.Name = name ?? "";
            }
            if (!string.IsNullOrWhiteSpace(description))
            {
                taskToEdit.Description = description;
            }
            db.SaveChanges();
        }

        /// <inheritdoc/>
        public Task? GetTaskById(int id)
        {
            using TaskDbContext db = new();
            return db.Tasks.Where((task) => task.Id == id).First();
        }

        /// <inheritdoc/>
        public IEnumerable<Task> GetTasks()
        {
            using TaskDbContext db = new();
            foreach (var task in db.Tasks)
            {
                yield return task;
            }
        }

        /// <inheritdoc/>
        public void RemoveTask(Task task)
        {
            using TaskDbContext db = new();
            Task? taskToDelete = GetTaskById(task.Id);
            if (taskToDelete != null)
            {
                db.Tasks.Attach(taskToDelete);
                db.Tasks.Remove(taskToDelete);
                db.SaveChanges();
            }
        }
    }
}
