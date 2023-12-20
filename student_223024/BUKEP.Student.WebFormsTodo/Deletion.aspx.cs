using BUKEP.Student.Todo;
using System;
using System.Web.UI;

namespace BUKEP.Student.WebFormsTodo
{
	public partial class Deletion : Page
	{
		private ITaskManager _taskManager;
		private Task _taskToDelete;
		protected void Page_Load(object sender, EventArgs e)
		{
			_taskManager = Session["_userData"] as ITaskManager;
			_taskToDelete = _taskManager.GetTaskById(int.Parse(Request["taskid"]));
			QuestionLabel.InnerText = $"Вы действительно хотите удалить задачу {_taskToDelete.Name}? Если да, то нажмите кнопку \"Удалить\", иначе нажмите \"Отмена\".";
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			_taskManager.RemoveTask(_taskToDelete);
			Response.Redirect("~/Todo.aspx");
		}
	}
}