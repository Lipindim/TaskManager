using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TaskManager.Domain.Entities;

namespace TaskManager.Client
{
    /// <summary>
    /// Логика взаимодействия для SelectUserWindow.xaml
    /// </summary>
    public partial class SelectUserWindow : Window
    {
        public User SelectedUser { get; set; }

        public SelectUserWindow(List<User> users, bool onlyWithoutManager = false)
        {
            InitializeComponent();
            if (onlyWithoutManager)
            {
                list_user.ItemsSource = users.Where(x => x.ManagerID == null && !x.IsBoss).ToList();
            }
            else
            {
                list_user.ItemsSource = users;
            }
        }

        private void list_user_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedUser = list_user.SelectedItem as User;
            DialogResult = true;
        }
    }
}
