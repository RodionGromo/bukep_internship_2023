using BUKEP.Student.Todo;
using BUKEP.Student.Todo.Data;
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
					// вот тут придется сменить
					// AttachDbFilename=E:\\workge\\student_223024\\BUKEP.Student.WebFormsTodo\\App_Data\\Database1.mdf
					// на свою ссылку БД, не знаю как по другому
					HttpContext.Current.Session["_userData"] = new TaskDatabase("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\workge\\student_223024\\BUKEP.Student.WebFormsTodo\\App_Data\\Database1.mdf;Integrated Security=True;");
				}
				return (ITaskManager)HttpContext.Current.Session["_userData"];
			}
		}
	}
}