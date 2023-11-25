using System.Collections.Generic;

namespace BUKEP.Student.WindowsTodo
{
    /// <summary>
    /// Класс TaskManager, перекрывает стандартный доступ к списку задач, заменяя его вспомогательными функциями
    /// </summary>
    public class TaskManager
    {
        /// <summary>
        /// Список задач
        /// </summary>
        private List<TaskItem> TaskList = new();

        /// <summary>
        /// Добавляет в список элемент item, если такой не существует
        /// </summary>
        /// <param name="item">Элемент, который нужно добавить</param>
        public void AddTask(TaskItem item)
        {
            if (!TaskList.Contains(item))
            {
                TaskList.Add(item);
            }
        }

        /// <summary>
        /// Создает и добавляет в список задачу, используя только название
        /// </summary>
        /// <param name="name">Название задачи</param>
        public void AddTask(string name) 
        {
            TaskItem item = new() { Name = name };
            if (!TaskList.Contains(item))
            {
                TaskList.Add(item);
            }
        }

        /// <summary>
        /// Создает и добавляет в список задачу, используя название + описание
        /// </summary>
        /// <param name="name">Название задачи</param>
        /// <param name="description">Описание задачи</param>
        public void AddTask(string name, string description)
        {
            TaskItem item = new() { Name = name, Description = description};
            if (!TaskList.Contains(item))
            {
                TaskList.Add(item);
            }
        }

        /// <summary>
        /// Удаляет из списка элемент
        /// </summary>
        /// <param name="item">Элемент, который нужно удалить</param>
        public void RemoveTask(TaskItem item)
        {
            TaskList.Remove(item);
        }

        /// <summary>
        /// Копирует и возвращает список задач
        /// </summary>
        public List<TaskItem> GetTasks()
        {
            return new(TaskList);
        }
    }
}
