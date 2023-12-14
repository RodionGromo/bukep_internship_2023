using BUKEP.Student.Todo;
using System.Linq;

namespace BUKEP.Student.WebFormsTodo
{
	/// <summary>
	/// Класс для хранения данных пользователя - ITaskManager и некоторые состояния
	/// </summary>
	public class UserState
	{
		/// <summary>
		/// Показывает, находится ли пользователь в режиме редактирования\создания задачи
		/// </summary>
		public bool IsInEditMode { get; set; } = false;

		/// <summary>
		/// Индивидуальный ITaskManager пользователя
		/// </summary>
		public ITaskManager UserTaskManager { get; set; }

		/// <summary>
		/// Task, который сейчас редактируется
		/// </summary>
		public Task EditingTask { get; set; }

		public override string ToString()
		{
			return $"[Userstate inEditMode: {IsInEditMode}, tasks: {UserTaskManager.GetTasks().ToList()}";
		}
	}
}