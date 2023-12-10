using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUKEP.Student.Todo;
using System.Diagnostics;


namespace BUKEP.Student.WebFormsTodo.Pages
{
	public class TodoModel : PageModel
    {
        public ITaskManager taskManager { get; set; } = new TaskManager();
        public Todo.Task taskToModify { get; set; } = new Todo.Task() { Name = string.Empty };
        public bool showModificationMenu { get; set; } = false;
		public bool editingTask { get; set; } = false;

        public void OnGet()
        {
			Debug.WriteLine(showModificationMenu);
		}

        public IActionResult OnPost(string handler)
        {
			Debug.WriteLine($"Got a POST from: {handler}");
			Debug.WriteLine(showModificationMenu);
			if (handler.Equals("ShowModificationMenu"))
			{
				Debug.WriteLine("showing mod menu");
				showModificationMenu = true;
				Debug.WriteLine(showModificationMenu);
			}
			if (handler.Equals("CloseModificationMenu"))
			{
				Debug.WriteLine("closing mod menu");
				showModificationMenu = false;
				Debug.WriteLine(showModificationMenu);
			}
			if(handler.Equals("SaveTask"))
			{
				if (Request.Form != null)
				{
					if (Request.Form["action"] == "save")
					{
						if (editingTask)
						{
							return Redirect("/Todo");
						}
						else
						{
							string? taskName = Request.Form["taskname"];
							string? taskDescription = Request.Form["taskdescr"];
							if (!string.IsNullOrWhiteSpace(taskName))
							{
								if (string.IsNullOrWhiteSpace(taskDescription))
								{
									taskDescription = string.Empty;
								}
								taskManager.AddTask(taskName, taskDescription);
							}
						}
					}
					else if (Request.Form["action"] == "cancel")
					{
						Debug.WriteLine("closing mod menu");
						showModificationMenu = false;
					}
				}
				
			}
			return Redirect("/Todo");
		}

        public IActionResult OnPostDeleteRedirect(string tname, string tdescr)
        {
            string url = $"/ConfirmDelete?name={tname}&descr={tdescr}";
			taskToModify = new Todo.Task() { Name = tname, Description = tdescr };
            return Redirect(url);
        }
    }
}
