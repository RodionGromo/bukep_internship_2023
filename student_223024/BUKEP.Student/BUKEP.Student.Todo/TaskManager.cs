namespace BUKEP.Student.Todo
{
    /// <summary>
    /// Класс TaskManager, перекрывает стандартный доступ к списку задач, заменяя его вспомогательными функциями
    /// </summary>
    public class TaskManager : ITaskManager
    {
        /// <summary>
        /// Список задач
        /// </summary>
        private List<TaskItem> TaskList = new();

        /// <inheritdoc/>
        public void AddTask(string name, string description)
        {
            TaskItem item = new() { Name = name.Trim(), Description = description.Trim() };
            if (!ContainsTask(item))
            {
                TaskList.Add(item);
            }
        }

        /// <inheritdoc/>
        public void RemoveTask(TaskItem item)
        {
            TaskList.Remove(item);
        }

        /// <summary>
        /// <para>Ищет task в списке задач, и возвращает true, если такой есть</para>
        /// <para>Пояснение - List.Contains не сравнивает значения внутри элементов, а только их ссылки, поэтому эта функция нужна</para>
        /// </summary>
        /// <param name="task">Задача, которую нужно найти</param>
        /// <returns>true если такой task существует, иначе false</returns>
        private bool ContainsTask(TaskItem task)
        {
            foreach (TaskItem item in TaskList)
            {
                if (item.Name.Equals(task.Name))
                {
                    if(item.Description != null && task.Description != null)
                    {
                        if (task.Description.Equals(item.Description)) {
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
        public List<TaskItem> GetTasks()
        {
            return new(TaskList);
        }
    }
}
