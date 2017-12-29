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
using TaskManager.Domain.Entities;
using TaskManager.Services;
using TaskManager.Services.Contract;

namespace TaskManager.Client.Controls
{
    /// <summary>
    /// Логика взаимодействия для EditTaskControl.xaml
    /// </summary>
    public partial class EditTaskControl : UserControl, ITaskEdit
    {
        ITaskContract taskContract;
        IUserContract userContract;

        public EditTaskControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            taskContract = ContractManager.GetTaskContract();
            userContract = ContractManager.GetUserContract();
        }

        public event Action EditEnd;

        public void SelectTask(Task task)
        {
            task.AccessorID = GlobalSettings.CurrentUser.ID;
            this.DataContext = task;
            if (task.ID != 0)
            {
                UpdateComment(task.ID);
            }
            else
            {
                lb_comment.ItemsSource = null;
            }
        }

        private void UpdateComment(int taskId)
        {
            lb_comment.ItemsSource = taskContract.GetComments(taskId).OrderBy(x => x.TimeCreated);
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as Task).ID == 0)
            {
                (this.DataContext as Task).TimeCreate = DateTime.Now;
                taskContract.AddTask(this.DataContext as Task);
            }
            else
            {
                taskContract.UpdateTask(this.DataContext as Task);
            }      
            EditEnd?.Invoke();
        }

        private void btn_addComment_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow commentWindow = new CommentWindow();
            if (commentWindow.ShowDialog() == true)
            {
                taskContract.AddComment(commentWindow.CurrentText, 
                    (this.DataContext as Task).ID, 
                    GlobalSettings.CurrentUser.ID);
                UpdateComment((this.DataContext as Task).ID);
            }
        }

        private void btn_selectExecutor_Click(object sender, RoutedEventArgs e)
        {
            List<User> executors = userContract.GetSubordinates(GlobalSettings.CurrentUser.ID);
            executors.Insert(0, GlobalSettings.CurrentUser);
            SelectUserWindow selectUserWindow = new SelectUserWindow(executors);
            if (selectUserWindow.ShowDialog() == true)
            {
                (this.DataContext as Task).Executor = selectUserWindow.SelectedUser;
                (this.DataContext as Task).ExecutorID = selectUserWindow.SelectedUser.ID;
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            EditEnd?.Invoke();
        }
    }
}
