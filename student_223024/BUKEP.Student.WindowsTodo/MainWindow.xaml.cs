using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BUKEP.Student.WindowsTodo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    	public List<TaskItem> TaskList = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создает диалоговое окно для подтверждения удаления задачи
        /// </summary>
        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            RemoveModal removeModal = new(sender);
            removeModal.ShowDialog();
            RefreshViewList();
        }

        /// <summary>
        /// Обновляет TaskViewList, удаляя все элементы и добавляя их снова
        /// </summary>
        public void RefreshViewList()
        {
            TaskViewList.Items.Clear();
            TaskViewList.Items.Add(TaskList);
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow win2 = new();
            win2.ShowDialog();
        }
    }
}
