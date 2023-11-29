namespace BUKEP.Student.Todo
{
    public interface ITaskManager
    {
        /// <summary>
        /// Создает и добавляет в список задачу, используя название + описание
        /// </summary>
        /// <param name="name">Название задачи</param>
        /// <param name="description">Описание задачи</param>
        void AddTask(string name, string description);

        /// <summary>
        /// Удаляет из списка элемент
        /// </summary>
        /// <param name="item">Элемент, который нужно удалить</param>
        void RemoveTask(TaskItem item);

        /// <summary>
        /// Копирует и возвращает список задач
        /// </summary>
        List<TaskItem> GetTasks();
    }
}
