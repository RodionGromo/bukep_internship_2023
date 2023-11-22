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
        public List<TaskItem> TaskList = new()
        {
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            TaskItem? data = ((Button)sender).DataContext as TaskItem;
            if (data != null)
            {
                TaskList.Remove(data);
                RefreshViewList();
            }
        }

        /// <summary>
        /// Обновляет TaskViewList, удаляя все элементы и добавляя их снова
        /// </summary>
        public void RefreshViewList()
        {
            TaskViewList.Items.Clear();
            foreach (var item in TaskList)
            {
                TaskViewList.Items.Add(item);
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow win2 = new();
            win2.Show();
        }
    }
}
