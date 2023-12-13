using BUKEP.Student.Todo;
using System.Linq;

namespace BUKEP.Student.WebFormsTodo
{
	/// <summary>
	/// Класс для хранения данных пользователя - ITaskManager и некоторые состояния
	/// </summary>
	public class UserState
	{
		// Показывает, находится ли пользователь в режиме редактирования\создания задачи
		public bool IsInEditMode { get; set; } = false;

		// Индивидуальный ITaskManager пользователя
		public ITaskManager UserTaskManager { get; set; }

		// Task, который сейчас редактируется
		public Task EditingTask { get; set; }

		public override string ToString()
		{
			return $"[Userstate inEditMode: {IsInEditMode}, tasks: {UserTaskManager.GetTasks().ToList()}";
		}
	}
}