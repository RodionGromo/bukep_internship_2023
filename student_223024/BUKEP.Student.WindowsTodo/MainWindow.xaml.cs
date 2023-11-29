﻿using BUKEP.Student.Todo;
using System.Windows;
using System.Windows.Controls;

namespace BUKEP.Student.WindowsTodo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ITaskManager taskManager = new TaskManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создает диалоговое окно для подтверждения удаления задачи
        /// </summary>
        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            TaskItem item = (TaskItem)((Button)sender).DataContext;
            RemoveModal removeModal = new(item, taskManager);
            removeModal.ShowDialog();
            RefreshViewList();
        }

        /// <summary>
        /// Обновляет TaskViewList, удаляя все элементы и добавляя их снова
        /// </summary>
        public void RefreshViewList()
        {
            TaskViewList.Items.Clear();
            foreach(TaskItem item in taskManager.GetTasks())
            {
                TaskViewList.Items.Add(item);
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow win2 = new(this, taskManager);
            win2.ShowDialog();
        }
    }
}
