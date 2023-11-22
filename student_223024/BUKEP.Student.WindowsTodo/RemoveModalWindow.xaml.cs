using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BUKEP.Student.WindowsTodo
{
    /// <summary>
    /// Логика взаимодействия для RemoveModal.xaml
    /// </summary>
    public partial class RemoveModal : Window
    {
        readonly MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);
        private readonly TaskItem itemToDelete;

        /// <summary>
        /// Инициализатор, аргумент sender должен быть передан с event'а кнопки в ListView, иначе кидает ошибку если аргумент равен null
        /// </summary>
        /// <param name="sender">аргумент sender из event'а кнопки находящейся в ListView</param>
        /// <exception cref="ArgumentException"></exception>
        public RemoveModal(object? sender)
        {
            if(sender == null)
            {
                throw new ArgumentException("sender is null");
            }
            itemToDelete = (TaskItem)((Button)sender).DataContext;
            InitializeComponent();
        }

        private void AcceptRemoval(object sender, RoutedEventArgs e)
        {
            if (itemToDelete != null)
            {
                mainWindow.TaskList.Remove(itemToDelete);
            }
            Close();
        }

        private void DenyRemoval(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
