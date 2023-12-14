using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUKEP.Student.WebFormsTodo
{
	public partial class Deletion : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["UserInfo"] is UserState userState)
			{
				if(userState.EditingTask != null)
				{
					QuestionLabel.InnerText = $"Вы действительно хотите удалить задачу {userState.EditingTask.Name}? Если да, то нажмите кнопку \"Удалить\", иначе нажмите \"Отмена\".";
				}
			} 
			else
			{
				Debug.WriteLine("no userstate or editing task is null");
				if(Session["UserInfo"] is UserState us)
				{
					Debug.Write("Task to edit: ");
					Debug.WriteLine(us.EditingTask.Name);
				}
				Response.Redirect("~/Todo.aspx");
			}
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			if(Session["UserInfo"] is UserState userState)
			{
				userState.UserTaskManager.RemoveTask(userState.EditingTask);
			}
			Response.Redirect("~/Todo.aspx");
		}
	}
}