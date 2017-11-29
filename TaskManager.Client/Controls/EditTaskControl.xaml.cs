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

namespace TaskManager.Client.Controls
{
    /// <summary>
    /// Логика взаимодействия для EditTaskControl.xaml
    /// </summary>
    public partial class EditTaskControl : UserControl, ITaskEdit
    {
        public EditTaskControl()
        {
            InitializeComponent();
        }

        public event Action EditEnd;

        public void SelectTask(Task task)
        {
            this.DataContext = task;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (EditEnd != null)
            {
                EditEnd();
            }
        }
    }
}
