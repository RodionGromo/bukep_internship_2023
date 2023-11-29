using BUKEP.Student.Todo;
using System.Windows;

namespace BUKEP.Student.WindowsTodo
{
    /// <summary>
    /// Логика взаимодействия для RemoveModal.xaml
    /// </summary>
    public partial class RemoveModal : Window
    {
        private ITaskManager taskManager;
        private TaskItem itemToDelete;

        /// <summary>
        /// Инициализатор, аргумент item должен быть типом TaskItem из списка TaskList
        /// </summary>
        public RemoveModal(TaskItem item, ITaskManager taskManager)
        {
            this.taskManager = taskManager;
            itemToDelete = item;
            InitializeComponent();
        }

        private void AcceptRemoval(object sender, RoutedEventArgs e)
        {
            if (itemToDelete != null)
            {
                taskManager.RemoveTask(itemToDelete);
            }
            Close();
        }

        private void DenyRemoval(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
