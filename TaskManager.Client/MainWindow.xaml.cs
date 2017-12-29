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
using TaskManager.Services.Helpers;

namespace TaskManager.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ITaskContract TaskContract { get; set; }
        public IUserContract UserContract { get; set; }

        public ITaskEdit iTaskEdit { get; set; }
        public ITaskSelect iTaskSelect { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TaskContract = ContractManager.GetTaskContract();
            UserContract = ContractManager.GetUserContract();
            iTaskEdit = editTaskControl;
            iTaskSelect = taskListControl;
            iTaskSelect.TaskSelected += ITaskSelect_TaskSelected;
            iTaskEdit.EditEnd += ITaskEdit_EditEnd;
        }

        private void ITaskEdit_EditEnd()
        {
            MoveToTaskPage();
        }

        private void ITaskSelect_TaskSelected(Task task)
        {
            iTaskEdit.SelectTask(task);
            MoveToEditPage();
        }

        private void MoveToEditPage()
        {
            tabControl.SelectedItem = tab_editTask;
        }
        private void MoveToTaskPage()
        {
            tabControl.SelectedItem = tab_tasks;
        }
    }
}
