using BUKEP.Student.Todo;
using System.Collections.Generic;

#nullable enable

namespace BUKEP.Student.MvcTodo.Models
{
    /// <summary>
    /// Модель данных для сайта
    /// </summary>
    public class TaskModel
    {
        public List<Task> Tasks { get; set; } = new List<Task>();
        public bool? EditMode { get; set; }
        public int? TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }

        public TaskModel(List<Task> tasks)
        {
            Tasks = tasks;
        }
    }
}