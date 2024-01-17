using BUKEP.Student.Todo;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace BUKEP.Student.MvcTodo.Models
{
    public class TaskModelsController : Controller
    {
        readonly ITaskManager _taskManager;

        public TaskModelsController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        // GET: TaskModels
        public ActionResult Index(bool? editMode=false, int? id=-1)
        {
            ViewBag.EditMode = editMode;
            ViewBag.Id = id;
            if(id > -1)
            {
                ViewBag.Name = _taskManager.GetTasks().Where((task) => task.Id == id).First().Name;
                ViewBag.Description = _taskManager.GetTasks().Where((task) => task.Id == id).First().Description;
            } 
            else
            {
                ViewBag.Name = string.Empty;
                ViewBag.Description = string.Empty;
            }
            return View(_taskManager.GetTasks());
        }

        // GET: Edit?id=_&taskName=_&taskDescription=_
        public ActionResult Edit(int id=-1, string taskName="", string taskDescription="")
        {
            if(id > -1)
            {
                _taskManager.EditTask(id, taskName, taskDescription);
                return Redirect("/TaskModels");
            }
            else
            {
                _taskManager.AddTask(taskName, taskDescription);
                return Redirect("/TaskModels");
            }
        }

        // GET: Delete?id=_
        public ActionResult Delete(int id=-1)
        {
            if(id > -1)
            {
                ViewBag.id = id;
                ViewBag.Name = _taskManager.GetTasks().Where((task) => task.Id == id).First().Name;
                return View();
            }
            return HttpNotFound();
        }

        // GET: Delete?id=_
        public ActionResult DeleteConfirmed(int id=-1)
        {
            if(id > -1)
            {
                Task taskToEdit = _taskManager.GetTasks().Where((task) => task.Id == id).First();
                _taskManager.RemoveTask(taskToEdit); 
                return Redirect("/TaskModels");
            }
            return HttpNotFound();
            
        }
    }
}
