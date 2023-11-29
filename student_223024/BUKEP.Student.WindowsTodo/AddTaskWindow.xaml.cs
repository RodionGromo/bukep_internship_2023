using BUKEP.Student.Todo;
using System.Windows;

namespace BUKEP.Student.WindowsTodo
{
    /// <summary>
    /// Логика взаимодействия для AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        MainWindow mainWindow;
        ITaskManager taskMan;
        const string enterTitleTemplate = "Введите заголовок задачи...";
        const string enterDescriptionTemplate = "Введите описание задачи...";

        public AddTaskWindow(MainWindow mw, ITaskManager tm)
        {
            mainWindow = mw;
            taskMan = tm;
            InitializeComponent();
        }

        private void RemoveTextTemplate_Name(object sender, RoutedEventArgs e)
        {
            if(TaskNameInput.Text.Equals(enterTitleTemplate))
            {
                TaskNameInput.Text = string.Empty;
            }
        }

        private void AddTextTemplate_Name(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskNameInput.Text))
            {
                TaskNameInput.Text = enterTitleTemplate.ToString();
            }
        }

        private void RemoveTextTemplate_Description(object sender, RoutedEventArgs e)
        {
            if (TaskDescriptionInput.Text.Equals(enterDescriptionTemplate))
            {
                TaskDescriptionInput.Text = string.Empty;
            }
        }

        private void AddTextTemplate_Description(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskDescriptionInput.Text))
            {
                TaskDescriptionInput.Text = enterDescriptionTemplate.ToString();
            }
        }

        /// <summary>
        /// Добавляет в TaskList задачу, с названием текста элемента TaskNameInput, и описанием текста элемента TaskDescriptionInput, если тот не равен шаблону
        /// </summary>
        private void SaveTask_Button(object sender, RoutedEventArgs e)
        {
            if (TaskNameInput.Text.Equals(enterTitleTemplate))
            {
                return;
            };

            string actualDescription = TaskDescriptionInput.Text.Equals(enterDescriptionTemplate) ? string.Empty : TaskDescriptionInput.Text;
            taskMan.AddTask(TaskNameInput.Text, actualDescription);
            mainWindow.RefreshViewList();
            Close();
        }

        private void ExitWindow_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
