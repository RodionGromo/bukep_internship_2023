using BUKEP.Student.Todo;
using BUKEP.Student.Todo.Data;
using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace BUKEP.Student.WebFormsTodo
{

    public partial class Todo : System.Web.UI.Page
    {
		readonly ITaskManager _taskManager = new DatabaseTaskManager(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

		/// <summary>
		/// Очищает все вводы на сайте
		/// </summary>
		/// <remarks>
		/// Впринципе не требуется, но это делает код чище
		/// </remarks>
		/// <param name="setEditPanelVisibility">Задаёт видимость панели редактирования/создания задачи</param>
		private void ClearEntries(bool setEditPanelVisibility)
        {
            taskNameEntry.Text = string.Empty;
            taskDescriptionEntry.Text = string.Empty;
            taskIDEntry.Text = string.Empty;
            EditPanel.Visible = setEditPanelVisibility;
        }

        /// <summary>
        /// Получает ID задачи из кнопки
        /// </summary>
        /// <param name="buttonObject">кнопка из event'а</param>
        /// <returns>ID задачи</returns>
        private int GetTaskIDFromButton(Button buttonObject)
        {
            GridViewRow row = (GridViewRow)buttonObject.NamingContainer;
            int.TryParse(TaskView.DataKeys[row.RowIndex].Values[0].ToString(), out int TaskID);
            return TaskID;
        }

        /// <summary>
        /// Используя GetTaskFromIDButton, возвращает Task
        /// </summary>
        /// <param name="buttonObject">кнпока из event'а</param>
        /// <returns>Задача из кнопки</returns>
        private Task GetTaskFromButton(Button buttonObject)
        {
            int taskid = GetTaskIDFromButton(buttonObject);
            return _taskManager.GetTaskById(taskid);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TaskView.DataSource = _taskManager.GetTasks();
            TaskView.DataBind();
        }

        protected void NewTaskButton_Click(object sender, EventArgs e)
        {
            ClearEntries(!EditPanel.Visible);
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Task taskToEdit = GetTaskFromButton((Button)sender);
            taskNameEntry.Text = taskToEdit.Name;
            taskDescriptionEntry.Text = taskToEdit.Description;
            taskIDEntry.Text = taskToEdit.Id.ToString();
            EditPanel.Visible = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Task taskToEdit = GetTaskFromButton((Button)sender);
            Response.Redirect($"/deletion?taskid={taskToEdit.Id}");
        }

        protected void CancelEdit_Click(object sender, EventArgs e)
        {
            ClearEntries(false);
        }

        protected void ConfirmEdit_Click(object sender, EventArgs e)
        {
            bool isEditing = int.TryParse(taskIDEntry.Text, out int taskId);
            bool HTMLinName = Regex.IsMatch(taskNameEntry.Text, @"<.*?>");
            bool HTMLinDescription = Regex.IsMatch(taskDescriptionEntry.Text, @"<.*?>");
            if (HTMLinName || HTMLinDescription)
            {
                ClearEntries(false);
                return;
            }
            if(!string.IsNullOrWhiteSpace(taskNameEntry.Text))
            {
				if (isEditing)
				{
					_taskManager.EditTask(taskId, taskNameEntry.Text, taskDescriptionEntry.Text);
				}
				else
				{
					_taskManager.AddTask(taskNameEntry.Text, taskDescriptionEntry.Text);
				}
			}
            ClearEntries(false);

            TaskView.DataSource = _taskManager.GetTasks();
            TaskView.DataBind();
        }
    }
}