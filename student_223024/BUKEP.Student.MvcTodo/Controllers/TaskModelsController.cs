using BUKEP.Student.Todo;
using System.Data;
using System.Linq;
using System.Web.Mvc;

# nullable enable

namespace BUKEP.Student.MvcTodo.Models
{
    /// <summary>
    /// Контроллер сайта /TaskModels
    /// </summary>
    public class TaskModelsController : Controller
    {
        readonly ITaskManager _taskManager;

        public TaskModelsController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        // GET: TaskModels
        public ActionResult Index(bool? editMode, int? id)
        {
            TaskModel taskModel = new TaskModel(_taskManager.GetTasks().ToList())
            {
                EditMode = editMode ?? false,
                TaskId = id,
                TaskName = string.Empty,
                TaskDescription = string.Empty
            };
            if(taskModel.TaskId != null)
            {
                taskModel.TaskName = _taskManager.GetTasks().Where((task) => task.Id == id).First().Name;
                taskModel.TaskDescription = _taskManager.GetTasks().Where((task) => task.Id == id).First().Description;
            } 
            return View(taskModel);
        }

        // GET: Edit?id=_&taskName=_&taskDescription=_
        public ActionResult Edit(int? id, string? taskName, string? taskDescription)
        {
            if (id != null)
            {
                _taskManager.EditTask((int)id, taskName, taskDescription);
                return Redirect("/TaskModels");
            }
            else
            {
                _taskManager.AddTask(taskName ?? "Задача без названия", taskDescription ?? "");
                return Redirect("/TaskModels");
            }
        }

        // GET: Delete?id=_
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                TaskModel taskModel = new TaskModel(_taskManager.GetTasks().ToList())
                {
                    TaskId = id,
                    TaskName = _taskManager.GetTasks().Where((task) => task.Id == id).First().Name
                };
                return View(taskModel);
            }
            return HttpNotFound();
        }

        // GET: Delete?id=_
        public ActionResult DeleteConfirmed(int? id)
        {
            if(id != null)
            {
                Task taskToEdit = _taskManager.GetTasks().Where((task) => task.Id == id).First();
                _taskManager.RemoveTask(taskToEdit); 
                return Redirect("/TaskModels");
            }
            return HttpNotFound();
            
        }
    }
}
