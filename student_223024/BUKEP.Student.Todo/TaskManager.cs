﻿namespace BUKEP.Student.Todo
{
    /// <summary>
    /// Класс для доступа к списку задач
    /// </summary>
    public class TaskManager : ITaskManager
    {
        // Список задач
        private readonly List<Task> _taskList = new();
        // Индекс для разности id задач
        private int _idIndex = 0;

        /// <inheritdoc/>
        public void AddTask(string name, string description)
        {
            Task item = new() { Name = name.Trim(), Description = description.Trim(), Id = _idIndex };
            if (!ContainsTask(item))
            {
                _taskList.Add(item);
                _idIndex++;
            }
        }

        /// <inheritdoc/>
        public void RemoveTask(Task item)
        {
            _taskList.Remove(item);
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
        public Task? GetTaskById(int id)
        {
            foreach (var task in _taskList)
            {
                if (task.Id == id)
                {
                    return task;
                }
            }
            return null;
        }

        /// <inheritdoc/>
        public void EditTask(int id, string? name, string? description)
        {
            if (name is null && description is null)
            {
                return;
            }
            foreach (var task in _taskList)
            {
                if (task.Id == id)
                {
                    int taskIndex = _taskList.IndexOf(task);
                    if (name is not null)
                    {
                        _taskList[taskIndex].Name = (task.Name != name) ? name : task.Name;
                    }
                    if (description is not null)
                    {
                        _taskList[taskIndex].Description = (task.Description != description) ? description : task.Description;
                    }
                    break;
                }
            }
        }
    }
}
