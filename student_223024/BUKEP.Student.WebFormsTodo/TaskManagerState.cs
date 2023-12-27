using BUKEP.Student.Todo;
using System.Web;

namespace BUKEP.Student.WebFormsTodo
{
	/// <summary>
	/// Класс хранения состояния пользователя и его TaskManager
	/// </summary>
	public static class TaskManagerState
	{
		/// <summary>
		/// Список задач, автоматически получаемый из HttpContext.Current.Session
		/// </summary>
		public static ITaskManager TaskManager
		{
			get
			{
				if (!(HttpContext.Current.Session["_userData"] is ITaskManager))
				{
					HttpContext.Current.Session["_userData"] = new TaskManager();
				}
				return (ITaskManager)HttpContext.Current.Session["_userData"];
			}
		}
	}
}