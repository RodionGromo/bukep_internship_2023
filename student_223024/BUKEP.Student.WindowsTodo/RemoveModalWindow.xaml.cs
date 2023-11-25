using System.Windows;

namespace BUKEP.Student.WindowsTodo
{
    /// <summary>
    /// Логика взаимодействия для RemoveModal.xaml
    /// </summary>
    public partial class RemoveModal : Window
    {
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private TaskItem itemToDelete;

        /// <summary>
        /// Инициализатор, аргумент item должен быть типом TaskItem из списка TaskList
        /// </summary>
        public RemoveModal(TaskItem item)
        {
            itemToDelete = item;
            InitializeComponent();
        }

        private void AcceptRemoval(object sender, RoutedEventArgs e)
        {
            if (itemToDelete != null)
            {
                mainWindow.taskMan.RemoveTask(itemToDelete);
            }
            Close();
        }

        private void DenyRemoval(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
