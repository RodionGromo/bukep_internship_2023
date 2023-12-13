using BUKEP.Student.Todo;
using System;
using System.Linq;
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

		protected void NewTaskButton_Click(object sender, EventArgs e)
		{
			EditUserStateDirectly((UserState us) =>
			{
				us.IsInEditMode = !us.IsInEditMode;
				return us;
			});
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["UserInfo"] == null) {
				Session["UserInfo"] = new UserState() { UserTaskManager = new TaskManager() };
			}
			UserState userInfo = Session["UserInfo"] as UserState;
			ITaskManager taskManager = userInfo.UserTaskManager;

			EditPanel.Visible = userInfo.IsInEditMode;

			// создание таблицы задач по данным сессии пользователя
			for (int i = 0; i < taskManager.GetTasks().Count(); i++)
			{
				Task task = taskManager.GetTasks().ToList()[i];

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
					CssClass = "btn btn-danger"
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

		protected void EditButton_Click(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			Task taskToEdit = null;
			EditUserStateDirectly((us) =>
			{
				int.TryParse(btn.CommandArgument, out int taskIndex);
				Task taskToCopy = us.UserTaskManager.GetTasks().ElementAt(taskIndex);
				taskToEdit = taskToCopy;
				us.EditingTask = taskToCopy;
				us.IsInEditMode = true;
				return us;
			});
			taskNameEntry.Text = taskToEdit.Name;
			taskDescriptionEntry.Text = taskToEdit.Description;
		}

		protected void DeleteButton_Click(object sender, EventArgs e) 
		{
			Button btn = sender as Button;
			EditUserStateDirectly((us) =>
			{
				int.TryParse(btn.CommandArgument, out int taskIndex);
				Task taskToDelete = us.UserTaskManager.GetTasks().ElementAt(taskIndex);
				us.UserTaskManager.RemoveTask(taskToDelete);
				us.IsInEditMode = false;
				return us;
			});
		}

		protected void CancelEdit_Click(object sender, EventArgs e)
		{
			EditUserStateDirectly((us) =>
			{
				us.IsInEditMode = false;
				return us;
			});
		}

		protected void ConfirmEdit_Click(object sender, EventArgs e) 
		{
			EditUserStateDirectly((userState) =>
			{
				if (userState.IsInEditMode)
				{
					if(userState.EditingTask != null)
					{
						EditUserStateDirectly((us) =>
						{
							us.UserTaskManager.EditTask(us.EditingTask, taskNameEntry.Text, taskDescriptionEntry.Text);
							us.EditingTask = null;
							return us;
						});
						taskNameEntry.Text = string.Empty;
						taskDescriptionEntry.Text = string.Empty;
					}
				}
				else
				{
					userState.UserTaskManager.AddTask(taskNameEntry.Text, taskDescriptionEntry.Text);
					taskNameEntry.Text = string.Empty;
					taskDescriptionEntry.Text = string.Empty;
				}
				userState.IsInEditMode = false;
				return userState;
			});
		}
	}
}