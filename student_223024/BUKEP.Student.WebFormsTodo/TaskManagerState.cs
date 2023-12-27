using BUKEP.Student.Todo;
<<<<<<< HEAD
using BUKEP.Student.Todo.Data;
=======
>>>>>>> bc568fe80d4867de17aa02348a08594263d9bec6
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
<<<<<<< HEAD
					// вот тут придется сменить
					// AttachDbFilename=E:\\workge\\student_223024\\BUKEP.Student.WebFormsTodo\\App_Data\\Database1.mdf
					// на свою ссылку БД, не знаю как по другому
					HttpContext.Current.Session["_userData"] = new TaskDatabase("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\workge\\student_223024\\BUKEP.Student.WebFormsTodo\\App_Data\\Database1.mdf;Integrated Security=True;");
=======
					HttpContext.Current.Session["_userData"] = new TaskManager();
>>>>>>> bc568fe80d4867de17aa02348a08594263d9bec6
				}
				return (ITaskManager)HttpContext.Current.Session["_userData"];
			}
		}
	}
}