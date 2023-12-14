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
		/// Удаляет задачу из списка по её индексу
		/// </summary>
		/// <param name="taskIndex">Индекс задачи, которую нужно удалить</param>
		void RemoveTask(int taskIndex);

		/// <summary>
		/// <para>Ищет task в списке задач, и возвращает true, если такой есть</para>
		/// <para>Пояснение - List.Contains не сравнивает значения внутри элементов, а только их ссылки, поэтому эта функция нужна</para>
		/// </summary>
		/// <param name="task">Задача, которую нужно найти</param>
		/// <returns>true если такой task существует, иначе false</returns>
		bool ContainsTask(Task task);

		/// <summary>
		/// Возвращает итератор списка задач
		/// </summary>
		IEnumerable<Task> GetTasks();

		/// <summary>
		/// Редактирует задачу task, заменяя её имя и\или описание
		/// </summary>
		/// <param name="task">Задача, которую нужно редактировать</param>
		/// <param name="name">Новое название</param>
		/// <param name="description">Новое описание</param>
		void EditTask(Task task, string? name, string? description);
	}
}
