using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                RemoveTaskItemAndRefresh(data);
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

        /// <summary>
        /// Удаляет элемент из списка TaskList и обновляет с помощью RefreshViewList
        /// </summary>
        /// <param name="item">TaskItem который надо удалить</param>
        public void RemoveTaskItemAndRefresh(TaskItem item) {
            TaskList.Remove(item);
            RefreshViewList();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow win2 = new();
            win2.Show();
        }
    }
}
