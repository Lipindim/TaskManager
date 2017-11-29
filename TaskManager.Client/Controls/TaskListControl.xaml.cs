using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Client.Controls.Base;
using TaskManager.Client.Converter;
using TaskManager.Domain.Entities;
using TaskManager.Services;
using TaskManager.Services.Contract;

namespace TaskManager.Client.Controls
{
    /// <summary>
    /// Логика взаимодействия для TaskListControl.xaml
    /// </summary>
    public partial class TaskListControl : UserControl, ITaskSelect
    {
        public event Action<Task> TaskSelected;

        public ITaskContract TaskContract { get; set; }

        public TaskListControl()
        {
            InitializeComponent();
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaskContract = ContractManager.GetTaskContract();
            lb_task.ItemsSource = TaskContract.GetTasks(1).OrderBy(x => x.TimeFinish).ToList();
        }

        private void lb_task_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TaskSelected != null)
            {
                TaskSelected(lb_task.SelectedItem as Task);
            }
            //new EditTaskWindow().ShowDialog();
        }
    }
}
