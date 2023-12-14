namespace BUKEP.Student.Todo
{
	/// <summary>
	/// Класс для доступа к списку задач
	/// </summary>
	public class TaskManager : ITaskManager
	{
		// Список задач
		private List<Task> _taskList = new();

		/// <inheritdoc/>
		public void AddTask(string name, string description)
		{
			Task item = new() { Name = name.Trim(), Description = description.Trim() };
			if (!ContainsTask(item))
			{
				_taskList.Add(item);
			}
		}

		/// <inheritdoc/>
		public void RemoveTask(Task item)
		{
			_taskList.Remove(item);
		}

		/// <inheritdoc/>
		public void RemoveTask(int taskIndex)
		{
			try
			{
				_taskList.RemoveAt(taskIndex);
			} 
			catch (ArgumentOutOfRangeException)
			{
				return;
			}
			
		}

		/// <inheritdoc/>
		public IEnumerable<Task> GetTasks()
		{
			foreach (var task in _taskList)
			{
				yield return task;
			}
		}

		/// <inheritdoc/>
		public bool ContainsTask(Task task)
		{
			foreach (Task item in _taskList)
			{
				if (item.Name.Equals(task.Name))
				{
					if (item.Description != null && task.Description != null)
					{
						if (task.Description.Equals(item.Description))
						{
							return true;
						}
					}
					else
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public void EditTask(Task task, string? name, string? description)
		{
			if(name is null && description is null)
			{
				return;
			}
			int taskIndex = _taskList.IndexOf(task);
			if (taskIndex != -1)
			{
				Task foundTask = _taskList[taskIndex];
				if(name is not null)
				{
					_taskList[taskIndex].Name = (foundTask.Name != name) ? name : foundTask.Name;
				}
				if(description is not null) 
				{
					_taskList[taskIndex].Description = (foundTask.Description != description) ? description : foundTask.Description;
				}
			}
		}
	}
}
