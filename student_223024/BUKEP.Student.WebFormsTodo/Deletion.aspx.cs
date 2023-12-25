﻿using BUKEP.Student.Todo;
using System;
using System.Web.UI;

namespace BUKEP.Student.WebFormsTodo
{
    public partial class Deletion : Page
    {
        private ITaskManager TaskManager
        {
            get
            {
                if (!(Session["_userData"] is ITaskManager))
                {
                    Session["_userData"] = new TaskManager();
                }
                return (ITaskManager)Session["_userData"];
            }
        }

        private Task _taskToDelete;
        protected void Page_Load(object sender, EventArgs e)
        {
            _taskToDelete = TaskManager.GetTaskById(int.Parse(Request["taskid"]));
            QuestionLabel.InnerText = $"Вы действительно хотите удалить задачу {_taskToDelete.Name}? Если да, то нажмите кнопку \"Удалить\", иначе нажмите \"Отмена\".";
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            TaskManager.RemoveTask(_taskToDelete);
            Response.Redirect("~/Todo.aspx");
        }
    }
}