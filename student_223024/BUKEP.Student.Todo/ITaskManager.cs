namespace BUKEP.Student.Todo
{
    /// <summary>
    /// Интерфейс менеджера доступа к списку задач
    /// </summary>
    public interface ITaskManager
    {
        /// <summary>
        /// Добавляет задачу
        /// </summary>
        /// <param name="name">Название задачи</param>
        /// <param name="description">Описание задачи</param>
        void AddTask(string name, string description);

        /// <summary>
        /// Удаляет из списка задачу
        /// </summary>
        /// <param name="task">Задача, которую нужно удалить</param>
        void RemoveTask(Task task);

        /// <summary>
        /// Возвращает Task по id
        /// </summary>
        /// <param name="id">ID, по которому искать задачу</param>
        /// <returns></returns>
        Task? GetTaskById(int id);

        /// <summary>
        /// Возвращает список задач
        /// </summary>
        IEnumerable<Task> GetTasks();

        /// <summary>
        /// Редактирует задачу под ID id, заменяя её имя и\или описание
        /// </summary>
        /// <param name="id">ID задачи, которую нужно редактировать</param>
        /// <param name="name">Новое название</param>
        /// <param name="description">Новое описание</param>
        void EditTask(int id, string? name, string? description);
    }
}
