using System.Windows;

namespace BUKEP.Student.WindowsTodo
{
    /// <summary>
    /// Логика взаимодействия для AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        readonly MainWindow MainWindow = ((MainWindow)Application.Current.MainWindow);

        readonly string enterTitleTemplate = "Введите заголовок задачи...";
        readonly string enterDescriptionTemplate = "Введите описание задачи...";

        public AddTaskWindow()
        {
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
            if(TaskNameInput.Text.Equals(enterTitleTemplate))
            {
                return;
            }
            string actualDescription = TaskDescriptionInput.Text.Equals(enterDescriptionTemplate) ? "" : TaskDescriptionInput.Text;
            MainWindow.TaskList.Add(new(TaskNameInput.Text, actualDescription));
            MainWindow.RefreshViewList();
            Close();
        }

        private void ExitWindow_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
