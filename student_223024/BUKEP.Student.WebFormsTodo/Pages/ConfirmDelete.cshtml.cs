using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;


namespace BUKEP.Student.WebFormsTodo.Pages
{
    public class ConfirmDeleteModel : PageModel
    {
        public string taskName = string.Empty;
		public string taskDescription = string.Empty;

        public void OnPost(string name, string descr)
        {
            taskDescription = descr;
            taskName = name;
            Debug.WriteLine($"Confirmation, delete: {taskName} {taskDescription}");
        }

        public IActionResult OnPostCancelDeletion() {
            return Redirect("/todo");
        }

        public IActionResult OnPostConfirmDeletion()
        {
            return Redirect($"/todo?taskName={taskName}&taskDescription={taskDescription}");
        }
    }
}
