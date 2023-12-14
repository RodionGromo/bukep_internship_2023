using BUKEP.Student.Todo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace BUKEP.Student.WebFormsTodo
{
	public partial class Todo : System.Web.UI.Page
	{
		private void EditUserStateDirectly(Func<UserState, UserState> f)
		{
			if (!(Session["UserInfo"] is UserState userdata))
			{
				throw new Exception("UserInfo is null somehow???");
			}
			userdata = f(userdata);
			Session["UserInfo"] = userdata;
		}

		private void RegenerateTaskTable(UserState userState)
		{
			ITaskManager taskManager = userState.UserTaskManager;
			IEnumerable<Task> tasks = taskManager.GetTasks();

			for (int i = 1; i < TaskTable.Rows.Count;i++) { 
				TaskTable.Rows.RemoveAt(i);
			}
			
			// создание таблицы задач по данным сессии пользователя
			for (int i = 0; i < tasks.Count(); i++)
			{
				Task task = tasks.ToList()[i];

				TableRow tr = new TableRow();

				TableCell taskNameCell = new TableCell
				{
					Text = task.Name
				};

				TableCell taskDescriptionCell = new TableCell
				{
					Text = task.Description
				};

				TableCell modifierButtonsCell = new TableCell();

				Button deleteButton = new Button
				{
					CommandName = "deleteTask",
					CommandArgument = i + "",
					Text = "Удалить",
					CssClass = "btn btn-danger",
				};

				Button editButton = new Button
				{
					CommandName = "editTask",
					CommandArgument = i + "",
					Text = "Изменить",
					CssClass = "btn btn-success",
				};
				editButton.Click += new EventHandler(EditButton_Click);
				deleteButton.Click += new EventHandler(DeleteButton_Click);

				modifierButtonsCell.Controls.Add(editButton);
				modifierButtonsCell.Controls.Add(deleteButton);

				tr.Cells.Add(taskNameCell);
				tr.Cells.Add(taskDescriptionCell);
				tr.Cells.Add(modifierButtonsCell);
				TaskTable.Rows.Add(tr);
			}
		}

		protected void NewTaskButton_Click(object sender, EventArgs e)
		{
			EditPanel.Visible = !EditPanel.Visible;
			if(Session["UserInfo"] is UserState us)
			{
				RegenerateTaskTable(us);
			}
			
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["UserInfo"] == null) {
				Session["UserInfo"] = new UserState() { UserTaskManager = new TaskManager() };
			}
		}

		protected void EditButton_Click(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			EditUserStateDirectly((us) =>
			{
				int.TryParse(btn.CommandArgument, out int taskIndex);
				Task taskToCopy = us.UserTaskManager.GetTasks().ElementAt(taskIndex);
				us.EditingTask = taskToCopy;
				us.IsInEditMode = true;

				taskNameEntry.Text = taskToCopy.Name;
				taskDescriptionEntry.Text = taskToCopy.Description;
				return us;
			});
			
			EditPanel.Visible = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e) 
		{
			Button btn = sender as Button;
			EditUserStateDirectly((us) =>
			{
				int.TryParse(btn.CommandArgument, out int taskIndex);
				us.EditingTask = us.UserTaskManager.GetTasks().ElementAt(taskIndex);
				RegenerateTaskTable(us);
				return us;
			});
			Response.Redirect("~/Deletion.aspx");
		}

		protected void CancelEdit_Click(object sender, EventArgs e)
		{
			EditUserStateDirectly((us) =>
			{
				us.IsInEditMode = false;
				RegenerateTaskTable(us);
				return us;
			});
			EditPanel.Visible = false;
		}

		protected void ConfirmEdit_Click(object sender, EventArgs e) 
		{
			bool HtmlInTitle = Regex.Match(taskNameEntry.Text, @"<(.|\n)*?>").Success;
			bool HtmlInDescription = Regex.Match(taskNameEntry.Text, @"<(.|\n)*?>").Success;
			if(HtmlInDescription || HtmlInTitle) {
				EditUserStateDirectly(us =>
				{
					us.IsInEditMode = false;
					RegenerateTaskTable(us);
					return us;
				});

				taskNameEntry.Text = string.Empty;
				taskDescriptionEntry.Text = string.Empty;
				EditPanel.Visible = false;
				return;
			}
			EditUserStateDirectly((userState) =>
			{
				if (userState.IsInEditMode && userState.EditingTask != null)
				{
					userState.UserTaskManager.EditTask(userState.EditingTask, taskNameEntry.Text, taskDescriptionEntry.Text);
					userState.EditingTask = null;
				}
				else
				{
					userState.UserTaskManager.AddTask(taskNameEntry.Text, taskDescriptionEntry.Text);
				}
				userState.IsInEditMode = false;

				taskNameEntry.Text = string.Empty;
				taskDescriptionEntry.Text = string.Empty;
				EditPanel.Visible = false;
				RegenerateTaskTable(userState);
				return userState;
			});
		}
	}
}